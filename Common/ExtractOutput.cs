using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public class ExtractOutput
    {
        private string MarkedHtml { get; set; }

        public ExtractOutput(string markedHtml)
        {
            MarkedHtml = markedHtml;
        }

        public void Extract(out string plainText, out string output)
        {
            var markReg = new Regex("<mark.*?>(\\{|\\})</mark>");
            var cidReg = new Regex("(?<=c-id=\")\\d+(?=\")");
            var ctypeReg = new Regex("(?<=c-type=\").+?(?=\")");
            var cnameReg = new Regex("(?<=c-name=\").+?(?=\")");


            var text_mark = MarkedHtml;
            var getTokenHelper = new PlainTextConverter(null, new List<string>() { "mark" });
            var markMatches = markReg.Matches(text_mark).ToList();
            var f1 = markMatches.Select(p => new MatchText(p.Index, p.Groups[1].Value == "{" ? "start" : "end", cidReg.Match(p.Value).Value, p.Value));
            var f2 = f1.GroupBy(p => p.cid).Select(p =>
                new MatchEntity(
                    p.Key,
                    p.First(q => q.startEnd == "start"),
                    p.First(q => q.startEnd == "end"),
                    ctypeReg.Match(p.First().matchText).Value,
                    cnameReg.Match(p.First().matchText).Value));
            List<MarkEntity> entityList = new List<MarkEntity>();
            foreach (var p in f2)
            {
                var token = text_mark.Substring(p.startMark.index + p.startMark.matchText.Length,
                    p.endMark.index - (p.startMark.index + p.startMark.matchText.Length));
                token = markReg.Replace(token, "");
                var t3 = new MarkEntity(p.cid, p.ctype, p.cname, p.startMark, p.endMark, token);
                entityList.Add(t3);
            }

            var orderedMarkMatches = markMatches.OrderBy(p => p.Index).ToList();
            var matchIndexList = new List<MarkHtml>();
            var text_plain_v2 = text_mark;
            for (var index = 0; index < orderedMarkMatches.Count; index++)
            {
                var match = orderedMarkMatches[index];
                var matchStr = match.Value;
                var t4 = new MarkHtml()
                {
                    MarkStr = matchStr,
                    Index = text_plain_v2.IndexOf(matchStr)
                };
                text_plain_v2 = text_plain_v2.Replace(matchStr, "");
                matchIndexList.Add(t4);
            }

            plainText = text_plain_v2;

            entityList = entityList.OrderBy(p => p.startMark.index).ToList();
            for (var index = 0; index < entityList.Count; index++)
            {
                var t3 = entityList[index];
                t3.SeqNo = index + 1;
                t3.startIndex = matchIndexList.First(p => p.MarkStr == t3.startMark.matchText).Index;
                t3.endIndex = matchIndexList.First(p => p.MarkStr == t3.endMark.matchText).Index;


                #region Test

                var calToken = text_plain_v2.Substring(t3.startIndex, t3.endIndex - t3.startIndex);
                if (calToken != t3.token)
                {
                    throw new Exception("Index Error");
                }

                #endregion
            }

            var lines = entityList.Select(p => $"{p.SeqNo}|{p.ctype}|{p.token}|{p.startIndex}|{p.endIndex}|{p.cname}");

            output = string.Join(Environment.NewLine, lines);
        }


        public class MatchText
        {
            public int index { get; }
            public string startEnd { get; }
            public string cid { get; }
            public string matchText { get; }

            public MatchText(int index, string startEnd, string cid, string matchText)
            {
                this.index = index;
                this.startEnd = startEnd;
                this.cid = cid;
                this.matchText = matchText;
            }
        }

        public class MatchEntity
        {
            public string cid { get; }
            public MatchText startMark { get; }
            public MatchText endMark { get; }
            public string ctype { get; }
            public string cname { get; }

            public MatchEntity(string cid, MatchText startMark, MatchText endMark, string ctype, string cname)
            {
                this.cid = cid;
                this.startMark = startMark;
                this.endMark = endMark;
                this.ctype = ctype;
                this.cname = cname;
            }
        }

        public class MarkEntity
        {
            public int SeqNo { get; set; }
            public string cid { get; }
            public string ctype { get; }
            public string cname { get; }
            public MatchText startMark { get; }
            public MatchText endMark { get; }
            public string token { get; }

            public int startIndex { get; set; }
            public int endIndex { get; set; }

            public MarkEntity(string cid, string ctype, string cname, MatchText startMark, MatchText endMark, string token)
            {
                this.cid = cid;
                this.ctype = ctype;
                this.cname = cname;
                this.startMark = startMark;
                this.endMark = endMark;
                this.token = token;
            }

        }

        public class MarkHtml
        {

            public int Index { get; set; }
            public string MarkStr { get; set; }
        }

    }
}
