using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Entity.Entities;
using Entity.Enum;
using Newtonsoft.Json;

namespace MarkByLearnedData
{
    public class Program
    {
        static IFreeSql fsql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.SqlServer, @"server=192.168.1.55;database=ArticleTag;uid=sa;pwd=deepbiodb@2019")
            .Build();
        /*static IFreeSql fsql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.SqlServer, @"server=deepbio-prod.sqlserver.rds.aliyuncs.com,1433;database=ArticleTag;uid=deepbioweb;pwd=7m*6Rkr2ip")
            .Build();*/
        static readonly PropertyInfo[] AutoTaggedPs = typeof(_temp_AutoTagged).GetProperties();
        static readonly List<Entity> BaseEntities = GetBaseEntities();

        static void Main(string[] args)
        {
            // var d = "10.1021/bi960038h";

            var autoTaggedData = fsql.Select<_temp_AutoTagged>().Where(p => p.state == null).ToList();
            for (var i = 0; i < autoTaggedData.Count; i++)
            {
                var learnedData = autoTaggedData[i];
                var doi = learnedData.doi.ToLower();
                if (string.IsNullOrWhiteSpace(doi))
                {
                    learnedData.state = "doi is empty";
                    fsql.Update<_temp_AutoTagged>(learnedData);
                    continue;
                }

                // get record
                var record = fsql.Select<ArticleTaggedRecord, CleanedArticle, RawArticle>()
                    .InnerJoin((a, b, c) => a.CleanedArticleID == b.ID && b.RawArticleID == c.ID)
                    .Where(p => p.t1.Status == TagArticleStatusEnum.Untagged && p.t1.AutoMarked == null && p.t3.DOI.ToLower() == doi).First();
                if (record == null || record.TaggedArray != null)
                {
                    learnedData.state = "record not exist by doi or tagged array not null";
                    fsql.Update<_temp_AutoTagged>(learnedData);
                    continue;
                }

                var html = record.TaggedContent;


                var taggedArray = new List<Tagged>();
                var entityIndex = 1;
                var successMarked = new List<string>();

                MarkEntity(learnedData, "AptamerType", ref entityIndex, ref html, taggedArray, successMarked);
                MarkEntity(learnedData, "AptamerName", ref entityIndex, ref html, taggedArray, successMarked);
                MarkEntity(learnedData, "Target", ref entityIndex, ref html, taggedArray, successMarked);
                MarkEntity(learnedData, "Affinity", ref entityIndex, ref html, taggedArray, successMarked);
                MarkEntity(learnedData, "Sequence", ref entityIndex, ref html, taggedArray, successMarked);
                MarkEntity(learnedData, "Sample", ref entityIndex, ref html, taggedArray, successMarked);
                MarkEntity(learnedData, "ScreenMethod", ref entityIndex, ref html, taggedArray, successMarked);
                MarkEntity(learnedData, "BindingBuffer", ref entityIndex, ref html, taggedArray, successMarked);
                MarkEntity(learnedData, "Application", ref entityIndex, ref html, taggedArray, successMarked);
                MarkEntity(learnedData, "ScreenCondition", ref entityIndex, ref html, taggedArray, successMarked);

                var taggedArrayStr = JsonConvert.SerializeObject(taggedArray);
                if (record.TaggedContent == html)
                {
                    learnedData.state = "all not marked";
                }
                else
                {
                    record.TaggedContent = html;
                    learnedData.state = $"success marked:{string.Join(",", successMarked)}";
                    record.TaggedArray = taggedArrayStr;
                    record.AutoMarked = 1;
                }

                var r = fsql.Update<_temp_AutoTagged>().SetSource(learnedData).ExecuteAffrows();
                var r2 = fsql.Update<ArticleTaggedRecord>().Set(p => p.TaggedContent == record.TaggedContent).Set(p => p.TaggedArray == record.TaggedArray).Set(p => p.AutoMarked == record.AutoMarked).Where(p => p.ID == record.ID).ExecuteAffrows();
                // var r1 = fsql.Update<_temp_AutoTagged>(learnedData);
                // var r2 = fsql.Update<ArticleTaggedRecord>(record);

                Console.WriteLine($"finished {i + 1}/{autoTaggedData.Count}");
            }
        }

        static void MarkEntity(_temp_AutoTagged learnedData, string entityName, ref int entityIndex, ref string html, List<Tagged> taggedArray, List<string> successMarked)
        {
            var markStart =
                "<mark id=\"mark-id-{0}\" class=\"tagged tagged-node\" tagtype=\"ts\" c-id=\"{0}\" c-type=\"{1}\" {2}  style=\"background-color: {3};\">{{</mark>";
            var markEnd =
                "<mark id=\"mark-id-{0}\" class=\"tagged tagged-node\" tagtype=\"te\" c-id=\"{0}\" c-type=\"{1}\" {2}  style=\"background-color: {3};\">}}</mark>";

            var p = AutoTaggedPs.First(p => p.Name == entityName);
            var pValue = p.GetValue(learnedData)?.ToString();
            if (!string.IsNullOrWhiteSpace(pValue))
            {
                var keywordReg = GetKeywordRegex(pValue);
                var keywordMatch = keywordReg.Match(html);
                if (!keywordMatch.Success)
                {
                    var p_state = AutoTaggedPs.First(p => p.Name == entityName + "_state");
                    p_state.SetValue(learnedData, "not found");
                    return;
                }


                Entity entity;
                string entityAndAttribute;
                if (entityName == "Target")
                {
                    entity = BaseEntities.First(p => p.label == entityName).children.First(p => p.label == "Protein");
                    entityAndAttribute = "c-name=\"Target\" c-attribute=\"Protein\"";
                }
                else
                {
                    entity = BaseEntities.First(p => p.label == entityName);
                    entityAndAttribute = $"c-name=\"{entityName}\"";
                }

                var markStartStr = string.Format(markStart, entityIndex, entity.type, entityAndAttribute, entity.color);
                var markEndStr = string.Format(markEnd, entityIndex, entity.type, entityAndAttribute, entity.color);
                var newMarkStr = markStartStr + keywordMatch.Value + markEndStr;
                html = keywordReg.Replace(html, newMarkStr, 1, 0);
                taggedArray.Add(new Tagged()
                {
                    ID = entityIndex.ToString(),
                    Name = entityName == "Target" ? "Target/Protein" : entityName,
                    Color = entity.color
                });
                entityIndex++;

                successMarked.Add(entityName);
            }
        }

        public static Regex GetKeywordRegex(string keyword)
        {
            keyword = Regex.Escape(keyword);
            var keywordRegStr = new Regex(@"([a-zA-Z]+)(?![a-zA-Z]*$)").Replace(keyword, "$1(<[/]?[^<>]+?>)*");


            /*
            var tagRegStr = "(<[/]?[^<>]+?>)*";
            new Regex(@"[a-zA-Z]*(?![a-zA-Z]*$)").Replace(keyword,)
            var charArray = keyword.ToCharArray().ToList();
            var keywordRegStr = "";
            for (var i = 0; i < charArray.Count - 1; i++)
            {
                keywordRegStr += charArray[i] + tagRegStr;
                if (i + 1 == charArray.Count - 1)
                {
                    keywordRegStr += charArray[i + 1];
                    break;
                }
            }*/

            var keywordReg = new Regex(keywordRegStr);
            return keywordReg;
        }

        static List<Entity> GetBaseEntities()
        {
            var entitiesJson =
                "[{\"value\":\"AptamerType\",\"label\":\"AptamerType\",\"color\":\"#FFFFCC\",\"type\":\"T\"},{\"value\":\"AptamerName\",\"label\":\"AptamerName\",\"color\":\"#CCFFFF\",\"type\":\"T\"},{\"value\":\"Sample\",\"label\":\"Sample\",\"color\":\"#FFCCCC\",\"type\":\"T\"},{\"value\":\"Target\",\"label\":\"Target\",\"type\":\"T\",\"children\":[{\"value\":\"Protein\",\"label\":\"Protein\",\"color\":\"#99CCCC\",\"type\":\"A\"},{\"value\":\"Compound\",\"label\":\"Compound\",\"color\":\"#FFCC99\",\"type\":\"A\"},{\"value\":\"Virus\",\"label\":\"Virus\",\"color\":\"#FF9999\",\"type\":\"A\"},{\"value\":\"Cells\",\"label\":\"Cells\",\"color\":\"#996699\",\"type\":\"A\"},{\"value\":\"Ion\",\"label\":\"Ion\",\"color\":\"#CC9999\",\"type\":\"A\"},{\"value\":\"Other\",\"label\":\"Other\",\"color\":\"#CCCC99\",\"type\":\"A\"}]},{\"value\":\"Affinity\",\"label\":\"Affinity\",\"color\":\"#FFFF99\",\"type\":\"T\"},{\"value\":\"Sequence\",\"label\":\"Sequence\",\"color\":\"#CCCCFF\",\"type\":\"T\"},{\"value\":\"ScreenMethod\",\"label\":\"ScreenMethod\",\"color\":\"#0099CC\",\"type\":\"T\"},{\"value\":\"ScreenCondition\",\"label\":\"ScreenCondition\",\"color\":\"#CCCCCC\",\"type\":\"T\"},{\"value\":\"BindingBuffer\",\"label\":\"BindingBuffer\",\"color\":\"#FF6666\",\"type\":\"T\"},{\"value\":\"Application\",\"label\":\"Application\",\"color\":\"#FF9966\",\"type\":\"T\"},{\"value\":\"References\",\"label\":\"References\",\"color\":\"#CC9966\",\"type\":\"T\"}]";
            var entities = JsonConvert.DeserializeObject<List<Entity>>(entitiesJson);
            return entities;
        }

    }

    public class Entity
    {
        public string value { get; set; }
        public string label { get; set; }
        public string color { get; set; }
        public string type { get; set; }
        public List<Entity> children { get; set; }
    }

    public class Tagged
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
