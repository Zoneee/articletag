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
            var htmlPath = @"F:\workspaces\ArticleCleanWorkspace\Plain Clean And Extract\1.html";
            var plainTextPath_mark = @"F:\workspaces\ArticleCleanWorkspace\Plain Clean And Extract\1_mark.txt";
            var plainTextPath_plain = @"F:\workspaces\ArticleCleanWorkspace\Plain Clean And Extract\1_plain.txt";
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
