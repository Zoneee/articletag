using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CleanRawArticleTool.Models;
using NLog;

namespace CleanRawArticleTool
{
    public class Cleaner
    {
        static IFreeSql fsql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.SqlServer, @"server=192.168.1.55;database=ArticleTag;uid=sa;pwd=deepbiodb@2019")
            .Build(); //请务必定义成 Singleton 单例模式 

        private readonly ILogger log;


        public void DoClean()
        {

            var rawArticles = fsql.Select<RawArticle>().Where(p => p.ContentFormat == TagContentFormatEnum.Html || p.ContentFormat == TagContentFormatEnum.PlainTextOrXml).Where(a =>
                !fsql.Select<CleanedArticle>().As("b").Where(b => b.RawArticleID == a.ID).Any());
            var count = rawArticles.Count();
            var rawArticle = rawArticles.First();
            var index = 0;
            while (rawArticle != null)
            {
                try
                {
                    var cleanedContent = rawArticle.ContentFormat == TagContentFormatEnum.Html ? Clean(rawArticle.RawContent, rawArticle.ID) : rawArticle.RawContent;
                    var cleanedObj = new CleanedArticle()
                    {
                        CleanedContent = cleanedContent,
                        CleanTime = DateTime.Now,
                        RawArticleID = rawArticle.ID
                    };
                    fsql.Insert(cleanedObj).ExecuteAffrows();
                    Console.WriteLine($"cleaned {++index}/{count}");
                }
                catch (Exception e)
                {
                    log.Error(e);
                }

                rawArticle = rawArticles.First();
            }
        }

        string Clean(string rawContent, long rawArticleID)
        {
            var urlPrefix = "http://img.staging.deepbiogroup.com/AptamerImageTotals/";
            var regImg = new Regex(@"<img[\s\S]*?src=""(?<src>.*?)""[\s\S]*?>(?!</img>)");

            var regBody = new Regex(@"[\s\S]*?(<body[\s\S]*?</body>)[\s\S]*");//只保留body
            var regNewLine = new Regex(@"\\n");//转换换行符
            var regTab = new Regex(@"\\t");//转换tab符
            var regShellB = new Regex(@"b'([\s\S]*)'");//脱壳 b''
            var regApostrophe = new Regex(@"\\'");//转换单引号
            var regLinkRef = new Regex(@"<link.*?href="".*?"".*?>\s*");//移除link引用
            var regScriptRef = new Regex(@"<script[^>]*?src="".*?""[^>]*?>[^<^>]*?</script>\s*");//移除script引用
            var regTagNewline = new Regex(@"((/>)|(</\w+?>))[ \t]*<");//标签换行
            var regScript = new Regex(@"<script.*?>[\s\S]*?</script>\s*");//移除script脚本
            var regHref = new Regex(@"<a([\s\S]*?)href=""(.*?)""");//清除a链接url
            var regStyleImgUrl = new Regex(@"url\(.*?\)");//清除css图片url
            var regSource = new Regex(@"<source[\s\S]*?>(?!</source>)");//清除source

            var cleanedContent = "";
            cleanedContent = regBody.Replace(rawContent, "$1");
            cleanedContent = regNewLine.Replace(cleanedContent, "\n");
            cleanedContent = regTab.Replace(cleanedContent, "\t");
            cleanedContent = regShellB.Replace(cleanedContent, "$1");
            cleanedContent = regApostrophe.Replace(cleanedContent, "'");
            cleanedContent = regLinkRef.Replace(cleanedContent, "");
            cleanedContent = regScriptRef.Replace(cleanedContent, "");
            cleanedContent = regTagNewline.Replace(cleanedContent, "$1\n<");
            cleanedContent = regTagNewline.Replace(cleanedContent, "$1\n<");
            cleanedContent = regTagNewline.Replace(cleanedContent, "$1\n<");
            cleanedContent = regScript.Replace(cleanedContent, "");
            cleanedContent = regHref.Replace(cleanedContent, "<a$1");
            cleanedContent = regStyleImgUrl.Replace(cleanedContent, "none");
            cleanedContent = regSource.Replace(cleanedContent, "");

            var imgMatches = regImg.Matches(cleanedContent);

            var figures = fsql.Select<RawArticleImgs>().Where(p => p.ArticleID == rawArticleID && p.ImgUrl != null && p.LocalImgPath != null).ToList().Select(p => new
            {
                originFileName = new FileInfo(p.ImgUrl).Name,
                localFileName = new FileInfo(p.LocalImgPath).Name
            }).ToList();
            if (figures.Any())
            {
                foreach (Match match in imgMatches)
                {
                    var imgUrl = match.Groups["src"]?.Value;
                    if (string.IsNullOrWhiteSpace(imgUrl))
                    {
                        continue;
                    }
                    var newUrl = "";
                    if (!string.IsNullOrWhiteSpace(imgUrl))
                    {
                        var origin_fileName = new FileInfo(imgUrl).Name;
                        var matchFigure = figures.FirstOrDefault(p => p.originFileName.ToLower() == origin_fileName.ToLower());
                        if (matchFigure != null)
                        {
                            newUrl = urlPrefix + matchFigure.localFileName;
                        }
                    }
                    cleanedContent = cleanedContent.Replace(imgUrl, newUrl);
                }

            }
            return cleanedContent;
        }
    }
}
