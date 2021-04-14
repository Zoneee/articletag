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
        public class T1
        {
            public int index { get; }
            public string startEnd { get; }
            public string cid { get; }
            public string matchText { get; }

            public T1(int index, string startEnd, string cid, string matchText)
            {
                this.index = index;
                this.startEnd = startEnd;
                this.cid = cid;
                this.matchText = matchText;
            }
        }

        public class T2
        {
            public string cid { get; }
            public T1 startMark { get; }
            public T1 endMark { get; }
            public string ctype { get; }
            public string cname { get; }

            public T2(string cid, T1 startMark, T1 endMark, string ctype, string cname)
            {
                this.cid = cid;
                this.startMark = startMark;
                this.endMark = endMark;
                this.ctype = ctype;
                this.cname = cname;
            }
        }

        public class T3
        {
            public string cid { get; }
            public string ctype { get; }
            public string cname { get; }
            public T1 startMark { get; }
            public T1 endMark { get; }
            public string token { get; }

            public int startIndex { get; set; }
            public int endIndex { get; set; }

            public T3(string cid, string ctype, string cname, T1 startMark, T1 endMark, string token)
            {
                this.cid = cid;
                this.ctype = ctype;
                this.cname = cname;
                this.startMark = startMark;
                this.endMark = endMark;
                this.token = token;
            }

        }

        public class T4
        {
            public int Index { get; set; }
            public string MatchStr { get; set; }
        }


        static void Main(string[] args)
        {
            // var path_plain = @"F:\workspaces\ArticleCleanWorkspace\Plain Clean And Extract\1_plain.txt";
            // var path_mark = @"F:\workspaces\ArticleCleanWorkspace\Plain Clean And Extract\demo_mark.txt";
            var path_mark = @"F:\workspaces\ArticleCleanWorkspace\Plain Clean And Extract\1_mark.txt";
            var markReg = new Regex("<mark.*?>(\\{|\\})</mark>");
            var cidReg = new Regex("(?<=c-id=\")\\d+(?=\")");
            var ctypeReg = new Regex("(?<=c-type=\").+?(?=\")");
            var cnameReg = new Regex("(?<=c-name=\").+?(?=\")");
            var text_mark = File.ReadAllText(path_mark);
            var getTokenHelper = new PlainTextConverter(null, new List<string>() { "mark" });
            var markMatches = markReg.Matches(text_mark).ToList();
            var f1 = markMatches.Select(p => new T1(p.Index, p.Groups[1].Value == "{" ? "start" : "end", cidReg.Match(p.Value).Value, p.Value));
            var f2 = f1.GroupBy(p => p.cid).Select(p => new T2(p.Key, p.First(q => q.startEnd == "start"), p.First(q => q.startEnd == "end"), ctypeReg.Match(p.First().matchText).Value, cnameReg.Match(p.First().matchText).Value));
            List<T3> f3 = new List<T3>();
            foreach (var p in f2)
            {
                var html = "<div>" +
                           text_mark.Substring(p.startMark.index,
                               p.endMark.index - p.startMark.index) + "</div>";
                var token = getTokenHelper.Convert(html);
                var t3 = new T3(p.cid, p.ctype, p.cname, p.startMark, p.endMark,token);
                f3.Add(t3);
            }

            var orderedMarkMatches = markMatches.OrderBy(p => p.Index).ToList();
            var matchIndexList = new List<T4>();
            foreach (var match in orderedMarkMatches)
            {
                var matchStr = match.Value;
                var t4 = new T4()
                {
                    MatchStr = matchStr,
                    Index = text_mark.IndexOf(matchStr)
                };
                text_mark = text_mark.Replace(matchStr, "");
                matchIndexList.Add(t4);
            }

            f3 = f3.OrderBy(p => p.startMark.index).ToList();
            foreach (var t3 in f3)
            {
                t3.startIndex = matchIndexList.First(p => p.MatchStr == t3.startMark.matchText).Index;
                t3.endIndex = matchIndexList.First(p => p.MatchStr == t3.endMark.matchText).Index - 1;
            }
        }
    }
}
