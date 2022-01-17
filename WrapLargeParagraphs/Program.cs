using System;
using System.Text.RegularExpressions;
using Entity.Entities;

namespace WrapLargeParagraphs
{
    /*
     * 一些文章是从pdf中提取，不是html,没有进行换行处理，导致呈现在页面上时是一整段没有段落的文字，很难阅读。
     * 其实并非没有段落，只是由于不是html，在页面上呈现时换行符仅当作空格显示了
     * 本程序将处理这种类型的文章
     */
    class Program
    {
        /*static IFreeSql fsql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.SqlServer, @"server=192.168.1.55;database=ArticleTag;uid=sa;pwd=deepbiodb@2019")
            .Build();*/
        static IFreeSql fsql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.SqlServer, 
                @"server=deepbio-prod.sqlserver.rds.aliyuncs.com,1433;database=ArticleTag;uid=zhanglianlian;pwd=3k%0S7r8Ah")
            .Build();
        static void Main(string[] args)
        {
            var processCatalog = "wrap_large_paragraph";
            var list = fsql.Select<ArticleTaggedRecord>()
                .WithSql(
                    $"select a.* from ArticleTaggedRecord a where a.id not in (select theid from BatchProcessHst where [Catalog] = '{processCatalog}')");
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

                var newContent = Wrap(obj.TaggedContent);
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

        static string Wrap(string content)
        {
            // recognize this kind of articles
            // no </body> </p> </div> </a> </li>
            var reg = new Regex("(</body>)|(</p>)|(</div>)|(</a>)|(</li>)");
            if (reg.Match(content).Success)
            {
                return content;
            }

            // use <br> to split paragraphs
            var newContent = content.Replace("\n", "<br>");
            return newContent;
        }
    }
}
