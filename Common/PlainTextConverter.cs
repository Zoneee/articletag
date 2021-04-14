using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace Common
{
    public class PlainTextConverter
    {
        public PlainTextConverter(List<string> _rawTagNames, List<string> _ignoreTagNames)
        {
            rawTagNames = _rawTagNames ?? new List<string>();
            ignoreTagNames = _ignoreTagNames ?? new List<string>();
        }

        private List<string> rawTagNames { get; }
        private List<string> ignoreTagNames { get; }

        /// <summary>
        ///     Converts HTML to plain text / strips tags.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <returns></returns>
        public string Convert(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var sw = new StringWriter();
            ConvertNode(doc.DocumentNode, sw);
            sw.Flush();
            var markText = sw.ToString();
            //remove multiple lines
            var linesReg = new Regex("(?:\\s*\\n\\s*){2,}");
            markText = linesReg.Replace(markText, "\r\n");
            return markText;
        }


        private void ConvertChildren(HtmlNode node, TextWriter outText)
        {
            var title = node.Attributes["title"]?.Value;
            foreach (var subNode in node.ChildNodes)
            {
                if (ignoreTagNames.Contains(subNode.Name)) continue;


                if (rawTagNames.Contains(subNode.Name))
                {
                    outText.Write(subNode.OuterHtml);
                    continue;
                }

                ConvertNode(subNode, outText);
            }
        }


        private void ConvertNode(HtmlNode node, TextWriter outText)
        {
            var text = "";
            switch (node.NodeType)
            {
                case HtmlNodeType.Comment:
                    // don't output comments
                    break;

                case HtmlNodeType.Document:
                    ConvertChildren(node, outText);
                    break;

                case HtmlNodeType.Text:
                    // script and style must not be output
                    var parentName = node.ParentNode.Name;
                    if (parentName == "script" || parentName == "style")
                        break;

                    text = ((HtmlTextNode)node).Text + "";

                    //如果两端有空白，就都保留一个空格
                    if (text.TrimStart().Length < text.Length) text = " " + text.TrimStart();

                    if (text.TrimEnd().Length < text.Length) text = text.TrimEnd() + " ";


                    var whiteSpaceReg = new Regex("\\s+");
                    text = whiteSpaceReg.Replace(text, " ");

                    // is it in fact a special closing node output as text?
                    if (HtmlNode.IsOverlappedClosingElement(text))
                        break;

                    // check the text is meaningful and not a bunch of whitespaces
                    if (text.Trim().Length > 0) outText.Write(HtmlEntity.DeEntitize(text));
                    break;

                case HtmlNodeType.Element:
                    if (node.Name == "noscript" || !IsNodeVisible(node)) break;

                    if (node.HasChildNodes) ConvertChildren(node, outText);

                    var blockElements = new List<string>
                    {
                        "p", "br", "div", "tr", "li","h1","h2","h3","h4","h5","h6","select"
                    };
                    if (blockElements.Contains(node.Name)) outText.Write("\r\n");

                    var spaceElements = new List<string>
                    {
                        "td","option"
                    };
                    if (spaceElements.Contains(node.Name)) outText.Write(" ");

                    break;
            }
        }

        private bool IsNodeVisible(HtmlNode node)
        {
            var attribute = node.Attributes["style"];

            bool thisVisible = attribute == null || CheckStyleVisibility(attribute.Value);

            return thisVisible;
        }

        private static bool CheckStyleVisibility(string style)
        {
            if (string.IsNullOrWhiteSpace(style))
                return true;

            var keys = ParseHtmlStyleString(style);

            if (keys.Keys.Contains("display"))
            {
                var display = keys["display"];
                if (display != null && display == "none")
                    return false;
            }

            if (keys.Keys.Contains("visibility"))
            {
                var visibility = keys["visibility"];
                if (visibility != null && visibility == "hidden")
                    return false;
            }

            return true;
        }

        public static Dictionary<string, string> ParseHtmlStyleString(string style)
        {
            var result = new Dictionary<string, string>();

            style = style.Replace(" ", "").ToLowerInvariant();

            var settings = style.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in settings)
            {
                if (!s.Contains(':'))
                    continue;
                var data = s.Split(':');
                result.Add(data[0], data[1]);
            }

            return result;
        }
    }
}