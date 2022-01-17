using System;
using System.Linq;
using System.Text.RegularExpressions;
using Entity.Entities;

namespace StatisticGarbled
{
    /*
     * 统计乱码文章数量
     * 正文中 连续4个问号 出现的次数达到50 即认为是乱码文章
     */
    class Program
    {

        static IFreeSql fsql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.SqlServer, @"server=192.168.1.55;database=ArticleTag;uid=sa;pwd=deepbiodb@2019")
            .Build();
        static void Main(string[] args)
        {
            var processCatalog = "statistic_garbled";
            var list = fsql.Select<ArticleTaggedRecord>()
                .WithSql(
                    $"select a.* from ArticleTaggedRecord a where a.id not in (select theid from BatchProcessHst where [Catalog] = '{processCatalog}')");
            var count = list.Count();

            for (var i = 0; i < count; i++)
            {
                try
                {
                    //because data in BatchProcessHst keep changing bellow, so every time just fetch the first one is ok to iterate the set
                    var obj = list.Take(1).First();
                    if (obj == null)
                    {
                        Console.WriteLine($"count is {count}");
                        Console.WriteLine($"real left count is {list.Count()}");
                        Console.Read();
                    }

                    var reg = new Regex(@"[\?]{4}");
                    var hst = new BatchProcessHst()
                    {
                        TheID = obj.ID,
                        Catalog = processCatalog
                    };
                    if (reg.Matches(obj.TaggedContent).Count() > 50)
                    {
                        hst.Modified = 1;
                    }

                    fsql.Insert(hst).ExecuteAffrows();

                    Console.WriteLine($"{count - i}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.Read();
                }

            }

            Console.WriteLine($"Finished. count is {count}, real left count is {list.Count()}");
        }
    }
}
