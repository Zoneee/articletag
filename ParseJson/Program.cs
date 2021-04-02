using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using CleanRawArticleTool;
using CleanRawArticleTool.Models;
using Deepbio.Domain.Entities.ArticleTagAggregateRoot;
using Deepbio.Domain.Enum;
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
            var rawArticles = fsql.Select<RawArticle>().Where(p => p.ContentFormat == TagContentFormatEnum.JsonHtml || p.ContentFormat == TagContentFormatEnum.PlainTextOrXml).Where(a =>
                !fsql.Select<CleanedArticle>().As("b").Where(b => b.RawArticleID == a.ID).Any());
            var total = rawArticles.Count();
            var index = 0;
            rawArticles.ToChunk(10, (batch =>
             {
                 foreach (var article in batch.Object)
                 {
                     try
                     {
                         var articleId = article.ID;
                         var imgs = fsql.Select<RawArticleImgs>().Where(p => p.ArticleID == articleId).ToList();

                         var contentJsonPart = GetContentJsonPart(article.RawContent);
                         var referenceJsonPart = GetReferenceJsonPart(article.RawContent);
                         var contentJson = new ContentJson(contentJsonPart, referenceJsonPart, imgs);
                         var html = contentJson.BuildHtml();

                         var cleanedArticleObj = new CleanedArticle()
                         {
                             CleanedContent = html,
                             CleanTime = DateTime.Now,
                             RawArticleID = articleId,
                         }.SetID();
                         fsql.Insert(cleanedArticleObj).ExecuteAffrows();

                         var taggedRecord = new ArticleTaggedRecord()
                         {
                             CleanedArticleID = cleanedArticleObj.ID,
                             Status = TagArticleStatusEnum.Tagging,
                             TaggedContent = cleanedArticleObj.CleanedContent
                         }.SetID();
                         fsql.Insert(taggedRecord).ExecuteAffrows();

                         Console.WriteLine($"cleaned {++index}/{total}");
                     }
                     catch (Exception e)
                     {
                         Console.WriteLine(e);
                     }
                 }
             }));
        }

        private static string GetContentJsonPart(string rawHtml)
        {
            return rawHtml.Split('\n').FirstOrDefault(p => p.StartsWith("{\"content\":[{\"#name\":\"body\""))?.Replace(@"\",@"\\");
        }

        private static string GetReferenceJsonPart(string rawHtml)
        {
            return rawHtml.Split('\n')
                .FirstOrDefault(p => p.StartsWith("{\"content\":[{\"#name\":\"bibliography\""))?.Replace(@"\", @"\\");
        }

    }
}
