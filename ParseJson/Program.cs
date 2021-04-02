using System;
using System.IO;
using System.Linq;
using CleanRawArticleTool;
using Newtonsoft.Json;

namespace ParseJson
{
    class Program
    {
        static IFreeSql fsql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.SqlServer, @"server=192.168.1.55;database=ArticleTag;uid=sa;pwd=deepbiodb@2019")
            .Build(); //请务必定义成 Singleton 单例模式 

        static void Main(string[] args)
        {
            // new Sample().Load();

            // var contentJsonPart = File.ReadAllText(@"F:\workspaces\ArticleCleanWorkspace\jsonFormatArticle\jsonFormatArticleContent.json");
            // var referenceJsonPart = File.ReadAllText(@"F:\workspaces\ArticleCleanWorkspace\jsonFormatArticle\jsonFormatArticleReferences.json");


            var articleId = 3918769900132;
            var imgs = fsql.Select<RawArticleImgs>().Where(p => p.ArticleID == articleId).ToList();
            
            var rawArticle = fsql.Select<RawArticle>().Where(p=>p.ID == articleId).First();
            var contentJsonPart = GetContentJsonPart(rawArticle.RawContent);
            var referenceJsonPart = GetReferenceJsonPart(rawArticle.RawContent);
            var contentJson = new ContentJson(contentJsonPart,referenceJsonPart,imgs); 
            var html = contentJson.BuildHtml();

            File.WriteAllText(@"F:\workspaces\ArticleCleanWorkspace\generatedHtml.html",html);
        }

        private static string GetContentJsonPart(string rawHtml)
        {
            return rawHtml.Split('\n').FirstOrDefault(p => p.StartsWith("{\"content\":[{\"#name\":\"body\""));
        }

        private static string GetReferenceJsonPart(string rawHtml)
        {
            return rawHtml.Split('\n')
                .FirstOrDefault(p => p.StartsWith("{\"content\":[{\"#name\":\"bibliography\""));
        }

    }
}
