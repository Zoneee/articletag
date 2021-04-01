using System;
using System.Collections.Generic;
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
        private JObject _root;
        private ElementMapping _em;
        public List<RawArticleImgs> _imgs;
        public ContentJson(string jsonStr, List<RawArticleImgs> rawArticleImgsList)
        {
            _imgs = rawArticleImgsList;
            _root = JObject.Parse(jsonStr);
            _em = new ElementMapping(this);
        }

        public string BuildHtml()
        {
            var html = "";

            //获取sections数组
            var sections = _root.SelectToken("$..[?(@.#name == 'sections')].$$");
            html = "<body>" + string.Join("\r\n", sections.Select(p => _em.GetHtmlByToken(p))) + "</body>";
            var formatedHtml = System.Xml.Linq.XElement.Parse(html).ToString();
            return formatedHtml;
        }

        public JArray floats
        {
            get
            {
                return _root["floats"] as JArray;
            }
        }

        public JArray attachments
        {
            get
            {
                return _root["attachments"] as JArray;
            }
        }


    }
}
