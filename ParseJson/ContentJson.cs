using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanRawArticleTool;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ParseJson
{
    public class ContentJson
    {
        private JObject _cotentRoot;
        private JObject _referenceRoot;
        private ElementMapping _em;
        public List<RawArticleImgs> _imgs;
        public ContentJson(string contentJsonPart, string referenceJsonPart, List<RawArticleImgs> rawArticleImgsList)
        {
            _imgs = rawArticleImgsList;
            _cotentRoot = JObject.Parse(contentJsonPart);
            _referenceRoot = JObject.Parse(referenceJsonPart);
            _em = new ElementMapping(this);
        }

        public string BuildHtml()
        {
            var html = $"<html><head><style>{GetPageStyle()}</style></head><body>{BuildContentHtml()}{BuildReferenceHtml()}</body></html>";
            var formatedHtml = System.Xml.Linq.XElement.Parse(html).ToString();
            return formatedHtml;
        }

        private string BuildContentHtml()
        {
            var contentHtml = "";
            var body = _cotentRoot.SelectToken("$..content[?(@.#name == 'body')]");
            if (body != null)
            {
                contentHtml = _em.GetHtmlByToken(body);
            }
            return contentHtml;
        }

        private string BuildReferenceHtml()
        {
            var referenceHtml = "";
            var bibliography = _referenceRoot.SelectToken("$..[?(@.#name == 'bibliography')]");
            if (bibliography != null)
            {
                referenceHtml = _em.GetHtmlByToken(bibliography);
            }

            return referenceHtml;
        }

        private string GetPageStyle()
        {
            return "ul li {list-style: none;}" +
                   "ul li p{display:inline;margin-left:10px;}" +
                   "table{border-collapse:collapse;}" +
                   "td{border:1px solid black;}" +
                   "thead td{font-weight:bold;}" +
                   ".authors .author{margin-right:10px;}" +
                   ".bib-reference{margin-bottom:10px;}";
        }

        public JArray floats
        {
            get
            {
                return _cotentRoot["floats"] as JArray;
            }
        }

        public JArray attachments
        {
            get
            {
                return _cotentRoot["attachments"] as JArray;
            }
        }


    }
}
