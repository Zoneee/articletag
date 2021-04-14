using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Common;

namespace CleanedHtmlToPlainText
{
    class Program
    {
        static void Main(string[] args)
        {
            // var htmlPath = @"F:\workspaces\ArticleCleanWorkspace\Plain Clean And Extract\demo.html";
            var no = 2;
            var htmlPath = $@"F:\workspaces\ArticleCleanWorkspace\Plain Clean And Extract\{no}.html";
            var plainTextPath_mark = $@"F:\workspaces\ArticleCleanWorkspace\Plain Clean And Extract\{no}_mark.txt";
            var plainTextPath_plain = $@"F:\workspaces\ArticleCleanWorkspace\Plain Clean And Extract\{no}_plain.txt";
            var html = "<html>" + File.ReadAllText(htmlPath) + "</html>";
            html = html.Replace("<sup>", "**").Replace("</sup>", "**").Replace("<sub>", "*").Replace("</sub>", "*");
            var text_mark = new PlainTextConverter(new List<string>() { "mark" }, null).Convert(html);
            var text_plain =
                new PlainTextConverter(null, new List<string>() { "mark" }).Convert(html);
            File.WriteAllText(plainTextPath_mark, text_mark);
            File.WriteAllText(plainTextPath_plain, text_plain);
        }
    }
}
