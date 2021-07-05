using System;
using System.Text.RegularExpressions;
using Entity.Entities;

namespace RemoveTranslateTag_cyxy
{
    /// <summary>
    /// 移除使用 彩云小译 翻译后的文章中的中文内容 class=cyxy-trs-target
    /// Catalog: remove_cyxy
    /// </summary>
    public class Program
    {
        static IFreeSql fsql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.SqlServer, @"server=192.168.1.55;database=ArticleTag;uid=webdeploy;pwd=webdeploy@2021")
            .Build();
        static void Main(string[] args)
        {
            var processCatalog = "remove_cyxy";

            /*var list = fsql.Select<ArticleTaggedRecord>()
                .WithSql(
                    $"select a.* from ArticleTaggedRecord a where a.id not in (select theid from BatchProcessHst where [Catalog] = '{processCatalog}')");*/
            var list = fsql.Select<ArticleTaggedRecord>()
                .WithSql(
                    $"select a.* from ArticleTaggedRecord a where a.lastChangeTime >'2021-7-5' and a.id not in (select theid from BatchProcessHst where [Catalog] = '{processCatalog}')");
            var count = list.Count();

            var i = 0;
            while (true)
            {
                //because data in BatchProcessHst keep changing bellow, so every time just fetch the first one is ok to iterate the set
                var obj = list.Take(1).First();
                if (obj == null)
                {
                    Console.WriteLine("Finished");
                    Console.Read();
                    return;
                }

                var newContent = Process(obj.TaggedContent);
                var hst = new BatchProcessHst()
                {
                    TheID = obj.ID,
                    Catalog = processCatalog,
                    _timestamp = DateTime.Now
                };
                if (newContent != obj.TaggedContent)
                {
                    var rows = fsql.Update<ArticleTaggedRecord>(obj.ID).Set(p => p.TaggedContent, newContent).ExecuteAffrows();
                    hst.Modified = 1;
                }

                fsql.Insert<BatchProcessHst>(hst).ExecuteAffrows();

                Console.WriteLine($"{++i}/{count}");
            }


        }
        public static string Process(string content)
        {
            /* 检查逻辑：
          1. 必须包含样式cyxy-trs-target
          2. 不能有非文本子元素
          */
            var reg = new Regex(@"<(?<tagName>\w+)\s*[^>]*class\s*=\s*[""'][^>]*cyxy-trs-target[^>]*[""'][^>]*>[^<>]*</\k<tagName>>");

            var newContent = reg.Replace(content, "");

            return newContent;
        }
    }
}
