using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Common;

namespace ExtractMarks
{
    class Program
    {
      


        static void Main(string[] args)
        {
            var no = 2;
            // var path_plain = @"F:\workspaces\ArticleCleanWorkspace\Plain Clean And Extract\1_plain.txt";
            // var path_mark = @"F:\workspaces\ArticleCleanWorkspace\Plain Clean And Extract\demo_mark.txt";
            var path_mark = $@"F:\workspaces\ArticleCleanWorkspace\Plain Clean And Extract\{no}_mark.txt";
            var path_plain_v2 = $@"F:\workspaces\ArticleCleanWorkspace\Plain Clean And Extract\{no}_plain_v2.txt";
            var path_output = $@"F:\workspaces\ArticleCleanWorkspace\Plain Clean And Extract\{no}_output.txt";

            var markedHtml = File.ReadAllText(path_mark);
            string plainText;
            string output;

            var extractor = new ExtractOutput(markedHtml);
            extractor.Extract(out plainText,out output);

            File.WriteAllText(path_plain_v2, plainText);
            File.WriteAllText(path_output,output);
        }
    }
}
