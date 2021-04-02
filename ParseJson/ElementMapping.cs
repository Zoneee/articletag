using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            var jsonName = ((JValue)token.SelectToken("$.#name"))?.Value?.ToString();
            switch (jsonName)
            {
                case "__text__":
                    return GetTextHtml(token);
                case "acknowledgment":
                    return GetAcknowledgmentHtml(token);
                case "appendices":
                    return GetAppendicesHtml(token);
                case "author":
                    return GetAuthorHtml(token);
                case "authors":
                    return GetAuthorsHtml(token);
                case "bib-reference":
                    return GetBibReferenceHtml(token);
                case "bibliography":
                    return GetBibliographyHtml(token);
                case "bibliography-sec":
                    return GetBibliographySec(token);
                case "body":
                    return GetBodyHtml(token);
                case "book":
                    return GetBookHtml(token);
                case "caption":
                    return GetCaptionHtml(token);
                case "colspec":
                    return GetColspecHtml(token);
                case "comment":
                    return GetCommentHtml(token);
                case "contribution":
                    return GetContributionHtml(token);
                case "cross-ref":
                    return GetCrossRefHtml(token);
                case "e-component":
                    return GetEComponentHtml(token);
                case "edited-book":
                    return GetEditedBook(token);
                case "edition":
                    return GetEditionHtml(token);
                case "editor":
                    return GetEditorHtml(token);
                case "date":
                    return GetDateHtml(token);
                case "display":
                    return GetDisplayHtml(token);
                case "doi":
                    return GetDoiHtml(token);
                case "editors":
                    return GetEditors(token);
                case "entry":
                    return GetEntryHtml(token);
                case "first-page":
                    return GetFirstPageHtml(token);
                case "float-anchor":
                    return GetFloatAnchorHtml(token);
                case "given-name":
                    return GetGivenNameHtml(token);
                case "grant-number":
                    return GetGrantNumber(token);
                case "grant-sponsor":
                    return GetGrantSponsor(token);
                case "host":
                    return GetHostHtml(token);
                case "hsp":
                    return GetHspHtml(token);
                case "inf":
                    return GetInfHtml(token);
                case "inter-ref":
                    return GetInterRefHtml(token);
                case "issue":
                    return GetIssueHtml(token);
                case "issue-nr":
                    return GetIssueNrHtml(token);
                case "italic":
                    return GetItalicHtml(token);
                case "label":
                    return GetLabelHtml(token);
                case "last-page":
                    return GetLastPageHtml(token);
                case "link":
                    return GetLinkHtml(token);
                case "list":
                    return GetListHtml(token);
                case "list-item":
                    return GetListItemHtml(token);
                case "location":
                    return GetLocationHtml(token);
                case "maintitle":
                    return GetMainTitleHtml(token);
                case "name":
                    return GetNameHtml(token);
                case "other-ref":
                    return GetOtherRefHtml(token);
                case "pages":
                    return GetPagesHtml(token);
                case "para":
                    return GetParaHtml(token);
                case "publisher":
                    return GetPublisherHtml(token);
                case "reference":
                    return GetReferenceHtml(token);
                case "row":
                    return GetRowHtml(token);
                case "section":
                    return GetSectionHtml(token);
                case "sections":
                    return GetSections(token);
                case "section-title":
                    return GetSectionTitleHtml(token);
                case "series":
                    return GetSeriesHtml(token);
                case "simple-para":
                    return GetSimpleParaHtml(token);
                case "sup":
                    return GetSupHtml(token);
                case "surname":
                    return GetSurNameHtml(token);
                case "table":
                    return GetTableHtml(token);
                case "tbody":
                    return GetTBodyHtml(token);
                case "textref":
                    return GetTextRefHtml(token);
                case "tgroup":
                    return GetTGroupHtml(token);
                case "thead":
                    return GetTHeadHtml(token);
                case "title":
                    return GetTitleHtml(token);
                case "volume-nr":
                    return GetVolumeNr(token);
                default:
                    throw new NotImplementedException();
            }
        }

        private string GetNameHtml(JToken name)
        {
            return $"<span {ClassAndID(name)}>{TryGetDirectValue(name)}{TryGetSubHtml(name)}</span>";
        }

        private string GetLocationHtml(JToken location)
        {
            return $"<span {ClassAndID(location)}>{TryGetDirectValue(location)}{TryGetSubHtml(location)}</span>";
        }

        private string GetEComponentHtml(JToken eComponent)
        {
            return $"<span {ClassAndID(eComponent)}>{TryGetDirectValue(eComponent)}{TryGetSubHtml(eComponent)}</span>";
        }

        private string GetPublisherHtml(JToken publisher)
        {
            return $"<span {ClassAndID(publisher)}>{TryGetDirectValue(publisher)}{TryGetSubHtml(publisher)}</span>";
        }

        private string GetGrantSponsor(JToken grantSponsor)
        {
            return $"<span {ClassAndID(grantSponsor)}>{TryGetDirectValue(grantSponsor)}{TryGetSubHtml(grantSponsor)}</span>";
        }

        private string GetGrantNumber(JToken grantNumber)
        {
            return $"<span {ClassAndID(grantNumber)}>{TryGetDirectValue(grantNumber)}{TryGetSubHtml(grantNumber)}</span>";
        }

        private string GetEditorHtml(JToken editor)
        {
            return $"<span {ClassAndID(editor)}>{TryGetDirectValue(editor)}{TryGetSubHtml(editor)}</span>";
        }

        private string GetEditionHtml(JToken edition)
        {
            return $"<span {ClassAndID(edition)}>{TryGetDirectValue(edition)}{TryGetSubHtml(edition)}</span>";
        }

        private string GetDisplayHtml(JToken display)
        {
            return $"<span {ClassAndID(display)}>{TryGetDirectValue(display)}{TryGetSubHtml(display)}</span>";
        }

        private string GetEditors(JToken editors)
        {
            return $"<span {ClassAndID(editors)}>{TryGetDirectValue(editors)}{TryGetSubHtml(editors)}</span>";
        }

        private string GetBookHtml(JToken book)
        {
            return $"<span {ClassAndID(book)}>{TryGetDirectValue(book)}{TryGetSubHtml(book)}</span>";
        }

        private string GetEditedBook(JToken editedBook)
        {
            return $"<div {ClassAndID(editedBook)}>{TryGetDirectValue(editedBook)}{TryGetSubHtml(editedBook)}</div>";
        }

        private string GetAppendicesHtml(JToken appendices)
        {
            return $"<div {ClassAndID(appendices)}>{TryGetDirectValue(appendices)}{TryGetSubHtml(appendices)}</div>";
        }

        private string GetAcknowledgmentHtml(JToken acknowledgment)
        {
            return $"<div {ClassAndID(acknowledgment)}>{TryGetDirectValue(acknowledgment)}{TryGetSubHtml(acknowledgment)}</div>";
        }

        private string GetFirstPageHtml(JToken firstPage)
        {
            return $"<span {ClassAndID(firstPage)}>{TryGetDirectValue(firstPage)}{TryGetSubHtml(firstPage)}</span>";
        }

        private string GetSeriesHtml(JToken series)
        {
            return $"<div {ClassAndID(series)}>{TryGetDirectValue(series)}{TryGetSubHtml(series)}</div>";
        }

        private string GetVolumeNr(JToken volumeNr)
        {
            return $"<span {ClassAndID(volumeNr)}>{TryGetDirectValue(volumeNr)}{TryGetSubHtml(volumeNr)}</span>";
        }

        private string GetTitleHtml(JToken title)
        {
            return $"<div {ClassAndID(title)}><strong>{TryGetDirectValue(title)}{TryGetSubHtml(title)}</strong></div>";
        }

        private string GetTextRefHtml(JToken textRef)
        {
            return $"<span {ClassAndID(textRef)}>{TryGetDirectValue(textRef)}{TryGetSubHtml(textRef)}</span>";
        }

        private string GetSurNameHtml(JToken surName)
        {
            return $"<span {ClassAndID(surName)}>{TryGetDirectValue(surName)}{TryGetSubHtml(surName)}</span>";
        }

        private string GetBodyHtml(JToken body)
        {
            return $"<div {ClassAndID(body)}>{TryGetDirectValue(body)}{TryGetSubHtml(body)}</div>";
        }

        private string GetSections(JToken sections)
        {
            return $"<div {ClassAndID(sections)}>{TryGetDirectValue(sections)}{TryGetSubHtml(sections)}</div>";
        }

        private string GetReferenceHtml(JToken reference)
        {
            return $"<dd {ClassAndID(reference)}>{TryGetDirectValue(reference)}{TryGetSubHtml(reference)}</dd>";
        }

        private string GetPagesHtml(JToken pages)
        {
            return $"<span {ClassAndID(pages)}>{TryGetDirectValue(pages)}{TryGetSubHtml(pages)}</span>";
        }

        private string GetOtherRefHtml(JToken otherRef)
        {
            return $"<div {ClassAndID(otherRef)}>{TryGetDirectValue(otherRef)}{TryGetSubHtml(otherRef)}</div>";
        }

        private string GetMainTitleHtml(JToken maintitle)
        {
            return $"<div {ClassAndID(maintitle)}>{TryGetDirectValue(maintitle)}{TryGetSubHtml(maintitle)}</div>";
        }

        private string GetLinkHtml(JToken link)
        {
            return $"";
        }

        private string GetLastPageHtml(JToken lastPage)
        {
            return $"<span {ClassAndID(lastPage)}>{TryGetDirectValue(lastPage)}{TryGetSubHtml(lastPage)}</span>";
        }

        private string GetIssueNrHtml(JToken issueNr)
        {
            return $"<span {ClassAndID(issueNr)}>{TryGetDirectValue(issueNr)}{TryGetSubHtml(issueNr)}</span>";
        }

        private string GetIssueHtml(JToken issue)
        {
            return $"<span {ClassAndID(issue)}>{TryGetDirectValue(issue)}{TryGetSubHtml(issue)}</span>";
        }

        private string GetInterRefHtml(JToken interRef)
        {
            return $"<span {ClassAndID(interRef)}>{TryGetDirectValue(interRef)}{TryGetSubHtml(interRef)}</span>";
        }

        private string GetHostHtml(JToken host)
        {
            return $"<div {ClassAndID(host)}>{TryGetDirectValue(host)}{TryGetSubHtml(host)}</div>";
        }

        private string GetGivenNameHtml(JToken givenName)
        {
            return $"<span {ClassAndID(givenName)}>{TryGetDirectValue(givenName)}{TryGetSubHtml(givenName)}</span>";
        }

        private string GetDoiHtml(JToken doi)
        {
            return $"<div {ClassAndID(doi)}>{TryGetDirectValue(doi)}{TryGetSubHtml(doi)}</div>";
        }

        private string GetDateHtml(JToken date)
        {
            return $"<span {ClassAndID(date)}>{TryGetDirectValue(date)}{TryGetSubHtml(date)}</span>";
        }

        private string GetContributionHtml(JToken contribution)
        {
            return $"<div {ClassAndID(contribution)}>{TryGetDirectValue(contribution)}{TryGetSubHtml(contribution)}</div>";
        }

        private string GetCommentHtml(JToken comment)
        {
            return $"<div {ClassAndID(comment)}>{TryGetDirectValue(comment)}{TryGetSubHtml(comment)}</div>";
        }

        private string GetBibReferenceHtml(JToken bigReferenece)
        {
            return $"<div {ClassAndID(bigReferenece)}>{TryGetDirectValue(bigReferenece)}{TryGetSubHtml(bigReferenece)}</div>";
        }

        private string GetBibliographyHtml(JToken bibliography)
        {
            return $"<section {ClassAndID(bibliography)}>{TryGetDirectValue(bibliography)}{TryGetSubHtml(bibliography)}</section>";
        }

        private string GetBibliographySec(JToken bibliographySec)
        {
            return $"<section {ClassAndID(bibliographySec)}><dl>{TryGetDirectValue(bibliographySec)}{TryGetSubHtml(bibliographySec)}</dl></section>";
        }

        private string GetAuthorHtml(JToken author)
        {
            return $"<span {ClassAndID(author)}>{TryGetDirectValue(author)}{TryGetSubHtml(author)}</span>";
        }

        private string GetAuthorsHtml(JToken authors)
        {
            return $"<span {ClassAndID(authors)}>{TryGetDirectValue(authors)}{TryGetSubHtml(authors)}</span>";
        }

        private string GetTBodyHtml(JToken tbody)
        {
            return $"<tbody>{TryGetSubHtml(tbody)}</tbody>";
        }

        private string GetTHeadHtml(JToken thead)
        {
            return $"<thead>{TryGetSubHtml(thead)}</thead>";
        }

        private string GetRowHtml(JToken row)
        {
            return $"<tr>{TryGetSubHtml(row)}</tr>";
        }

        private string GetEntryHtml(JToken entry)
        {
            return $"<td>{TryGetDirectValue(entry)}{TryGetSubHtml(entry)}</td>";
        }

        private string GetColspecHtml(JToken colspec)
        {
            return "";
        }

        private string GetTableHtml(JToken table)
        {
            return $"<div {ClassAndID(table)}>{TryGetDirectValue(table)}{TryGetSubHtml(table)}</div>";
        }

        private string GetTGroupHtml(JToken tgroup)
        {
            return $"<table {ClassAndID(tgroup)}>{TryGetSubHtml(tgroup)}</table>";
        }

        private string GetListHtml(JToken list)
        {
            return $"<ul {ClassAndID(list)}>{TryGetDirectValue(list)}{TryGetSubHtml(list)}</ul>";
        }

        private string GetListItemHtml(JToken listitem)
        {
            return $"<li {ClassAndID(listitem)}>{TryGetDirectValue(listitem)}{TryGetSubHtml(listitem)}</li>";
        }

        private string GetSimpleParaHtml(JToken token)
        {
            return GetParaHtml(token);
        }

        private string GetCaptionHtml(JToken token)
        {
            return $"<div {ClassAndID(token)}>{TryGetDirectValue(token)}{TryGetSubHtml(token)}</div>";
        }

        private string GetCrossRefHtml(JToken crossRef)
        {
            var html = "";
            var refId = crossRef.SelectToken("$.$.refid").ToString();
            var refToken = _cj.floats.FirstOrDefault(p => p["$"]["id"]?.ToString() == refId);
            if (refToken != null)
            {
                var refType = refToken["#name"].ToString();

                var label = refToken["$$"]?.FirstOrDefault(p => p["#name"]?.ToString() == "label")?["_"]?.ToString();
                html = $"<a href='#{refId}'>({label})</a>";
                var section = crossRef.Ancestors().Where(p => p.SelectToken("$.$$") != null).Where(p => p["#name"]?.ToString() == "section").FirstOrDefault();
                if (section != null)
                {
                    var sectionId = section["$"]["id"].ToString();
                    DicSectionRefHtml.TryGetValue(sectionId, out var sectionRefHtml);
                    var thisRefHtml = "";
                    switch (refType)
                    {
                        case "figure":
                            {
                                var locator = refToken["$$"]?.FirstOrDefault(p => p["#name"]?.ToString() == "link")?["$"]?["locator"]?.ToString();

                                var attachment = _cj.attachments.FirstOrDefault(p =>
                                    p["file-basename"]?.ToString() == locator &&
                                    p["attachment-type"]?.ToString() == "IMAGE-DOWNSAMPLED");

                                if (attachment != null)
                                {
                                    var originFileName = attachment["attachment-eid"]?.ToString();
                                    var imgObj = _cj._imgs.FirstOrDefault(p =>
                                        p.ImgUrl.Contains(originFileName, StringComparison.CurrentCultureIgnoreCase));
                                    if (imgObj != null)
                                    {
                                        var localFileName = new FileInfo(imgObj.LocalImgPath).Name;
                                        if (sectionRefHtml?.Contains(localFileName) != true)
                                        {
                                            thisRefHtml = $"<div id='{refId}'><div><img src='http://img.deepbiogroup.com/AptamerImageTotals/{localFileName}'/></div>" +
                                                          $"<div>{label}</div>" +
                                                          $"<div>{GetCaptionHtml(refToken["$$"]?.FirstOrDefault(p => p["#name"]?.ToString() == "caption"))}</div>" +
                                                          $"</div>";
                                        }
                                    }
                                }
                            }
                            break;
                        case "table":
                            {
                                thisRefHtml = GetTableHtml(refToken);
                            }
                            break;
                    }

                    sectionRefHtml += thisRefHtml;
                    DicSectionRefHtml[sectionId] = sectionRefHtml;
                }

            }
            return html;
        }

        private string GetFloatAnchorHtml(JToken anchor)
        {
            return "";
        }

        private string GetInfHtml(JToken inf)
        {
            var html = $"<sub {ClassAndID(inf)}>{TryGetDirectValue(inf)}{TryGetSubHtml(inf)}</sub>";
            return html;
        }

        private string GetSupHtml(JToken sup)
        {
            var html = $"<sup {ClassAndID(sup)}>{TryGetDirectValue(sup)}{TryGetSubHtml(sup)}</sup>";
            return html;
        }

        private string GetHspHtml(JToken hsp)
        {
            return " ";
        }

        private string GetItalicHtml(JToken italic)
        {
            var html = $"<em style='font-style: italic;' {ClassAndID(italic)}>{TryGetDirectValue(italic)}{TryGetSubHtml(italic)}</em>";
            return html;
        }

        private string GetTextHtml(JToken text)
        {
            return TryGetDirectValue(text);
        }

        private string GetParaHtml(JToken para)
        {
            var html = $"<p {ClassAndID(para)}>{TryGetDirectValue(para)}{TryGetSubHtml(para)}</p>";
            return html;
        }

        private string GetSectionTitleHtml(JToken sectionTitle)
        {
            var html = $"<h2 {ClassAndID(sectionTitle)}>{TryGetDirectValue(sectionTitle)}{TryGetSubHtml(sectionTitle)}</h2>";
            return html;
        }

        private string GetSectionHtml(JToken section)
        {
            var sectionId = section.SelectToken("$.$.id").ToString();
            var html = $"<section {ClassAndID(section)}>" +
                       $"{TryGetDirectValue(section)}" +
                       $"{TryGetSubHtml(section)}";
            DicSectionRefHtml.TryGetValue(sectionId, out var sectionRefHtml);
            html += sectionRefHtml + $"</section><hr/>";
            return html;
        }
        string GetLabelHtml(JToken label)
        {
            string html;
            if (label.Parent.Parent.Parent["#name"]?.ToString() == "bibliographySec-sec")
            {
                html = $"<dt {ClassAndID(label)}>{TryGetDirectValue(label)}{TryGetSubHtml(label)}</dt>"; ;
            }
            else
            {
                html = $"<span {ClassAndID(label)}>{TryGetDirectValue(label)}{TryGetSubHtml(label)}</span>"; ;
            }
            return html?.ToString();
        }

        private string ClassAndID(JToken token)
        {
            var tokenName = token.SelectToken("$.#name");
            return $" class='{tokenName}' id='{token.SelectToken("$.$.id")}' title='{tokenName}' ";
        }

        private string TryGetDirectValue(JToken token)
        {
            var val = (token["_"] as JValue)?.Value?.ToString().Replace("&", "&amp;");
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
