using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ParseJson
{
    public class ElementMapping
    {
        private ContentJson _cj;
        public ElementMapping(ContentJson contentJson)
        {
            _cj = contentJson;
        }

        public Dictionary<string, string> DicSectionRefHtml = new Dictionary<string, string>();

        public string GetHtmlByToken(JToken token)
        {
            var jsonName = ((JValue)token.SelectToken("$.#name")).Value?.ToString();
            switch (jsonName)
            {
                case "section":
                    return GetSectionHtml(token);
                case "label":
                    return GetLabelHtml(token);
                case "section-title":
                    return GetSectionTitleHtml(token);
                case "para":
                    return GetParaHtml(token);
                case "__text__":
                    return GetTextHtml(token);
                case "italic":
                    return GetItalicHtml(token);
                case "cross-ref":
                    return GetCrossRefHtml(token);
                case "hsp":
                    return GetHspHtml(token);
                case "float-anchor":
                    return GetAnchorHtml(token);
                case "inf":
                    return GetInfHtml(token);
                case "sup":
                    return GetSupHtml(token);
                case "anchor":
                    return GetAnchorHtml(token);
                case "caption":
                    return GetCaptionHtml(token);
                case "simple-para":
                    return GetSimpleParaHtml(token);
                default:
                    return $"<notimpl_{jsonName} />";
            }
        }

        private string GetSimpleParaHtml(JToken token)
        {
            return GetParaHtml(token);
        }

        private string GetCaptionHtml(JToken token)
        {
            return $"<div {TypeAndID(token)}>{TryGetDirectValue(token)}{TryGetSubHtml(token)}</div>";
        }

        private string GetCrossRefHtml(JToken crossRef)
        {
            var html = "";
            var refId = crossRef.SelectToken("$.$.refid").ToString();
            var refObj = _cj.floats.FirstOrDefault(p => p["$"]["id"]?.ToString() == refId);
            if (refObj != null)
            {
                var label = refObj["$$"]?.FirstOrDefault(p => p["#name"]?.ToString() == "label")?["_"]?.ToString();
                html = $"<a href='#{refId}'>({label})</a>";
                var section = crossRef.Ancestors().Where(p => p.SelectToken("$.$$") != null).Where(p => p["#name"]?.ToString() == "section").FirstOrDefault();
                if (section != null)
                {
                    var sectionId = section["$"]["id"].ToString();
                    DicSectionRefHtml.TryGetValue(sectionId, out var sectionRefHtml);

                    var locator = refObj["$$"]?.FirstOrDefault(p => p["#name"]?.ToString() == "link")?["$"]?["locator"]?.ToString();

                    var attachment = _cj.attachments.FirstOrDefault(p =>
                        p["file-basename"]?.ToString() == locator &&
                        p["attachment-type"]?.ToString() == "IMAGE-DOWNSAMPLED");

                    if (attachment != null)
                    {
                        var originFileName = attachment["attachment-eid"]?.ToString();
                        var imgObj = _cj._imgs.FirstOrDefault(p =>
                            p.ImgUrl.Contains(originFileName, StringComparison.CurrentCultureIgnoreCase));
                        var localFileName = new FileInfo(imgObj.LocalImgPath).Name;
                        if (sectionRefHtml?.Contains(localFileName) != true)
                        {
                            var sectionHtml = $"<div id='{refId}'><div><img src='http://img.deepbiogroup.com/AptamerImageTotals/{localFileName}'/></div>" +
                                              $"<div>{label}</div>" +
                                              $"<div>{GetCaptionHtml(refObj["$$"]?.FirstOrDefault(p => p["#name"]?.ToString() == "caption"))}</div>" +
                                              $"</div>";
                            sectionRefHtml += sectionHtml;
                            DicSectionRefHtml[sectionId] = sectionRefHtml;
                        }

                    }
                }

            }
            return html;
        }

        private string GetAnchorHtml(JToken anchor)
        {
            return "";
        }

        private string GetInfHtml(JToken inf)
        {
            var html = $"<sub {TypeAndID(inf)}>{TryGetDirectValue(inf)}{TryGetSubHtml(inf)}</sub>";
            return html;
        }

        private string GetSupHtml(JToken sup)
        {
            var html = $"<sup {TypeAndID(sup)}>{TryGetDirectValue(sup)}{TryGetSubHtml(sup)}</sup>";
            return html;
        }

        private string GetHspHtml(JToken hsp)
        {
            return " ";
        }

        private string GetItalicHtml(JToken italic)
        {
            var html = $"<em style='font-style: italic;' {TypeAndID(italic)}>{TryGetDirectValue(italic)}{TryGetSubHtml(italic)}</em>";
            return html;
        }


        private string GetTextHtml(JToken text)
        {
            return TryGetDirectValue(text);
        }

        private string GetParaHtml(JToken para)
        {
            var html = $"<p {TypeAndID(para)}>{TryGetDirectValue(para)}{TryGetSubHtml(para)}</p>";
            return html;
        }

        private string GetSectionTitleHtml(JToken sectionTitle)
        {
            var html = $"<h2 {TypeAndID(sectionTitle)}>{TryGetDirectValue(sectionTitle)}{TryGetSubHtml(sectionTitle)}</h2>";
            return html;
        }

        private string GetSectionHtml(JToken section)
        {
            var sectionId = section.SelectToken("$.$.id").ToString();
            var html = $"<section {TypeAndID(section)}>" +
                       $"{TryGetDirectValue(section)}" +
                       $"{TryGetSubHtml(section)}";
            DicSectionRefHtml.TryGetValue(sectionId, out var sectionRefHtml);
            html += sectionRefHtml + $"</section><hr/>";
            return html;
        }
        string GetLabelHtml(JToken label)
        {
            var html = $"<span {TypeAndID(label)}>{TryGetDirectValue(label)}{TryGetSubHtml(label)}</span>"; ;
            return html?.ToString();
        }





        private string TypeAndID(JToken token)
        {
            return $" type='{token.SelectToken("$.#name")}' id='{token.SelectToken("$.$.id")}' ";
        }

        private string TryGetDirectValue(JToken token)
        {
            var val = (token["_"] as JValue)?.Value?.ToString().Replace("&","&amp;");
            return val?.Replace("<", "&lt;")?.Replace(">", "&gt;");
        }

        private string TryGetSubHtml(JToken token)
        {
            var html = "";
            var subEles = token.SelectToken("$.$$")?.Select(p => GetHtmlByToken(p));
            if (subEles?.Any() == true)
            {
                html += string.Join("\r\n", subEles);
            }

            return html;
        }
    }
}
