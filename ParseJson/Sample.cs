using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ParseJson
{
    public class Sample
    {
        public void Load()
        {
            var html = File.ReadAllText(@"F:\workspaces\ArticleCleanWorkspace\generatedHtml.html");
            // JObject o = JObject.Parse(File.ReadAllText(@"F:\workspaces\ArticleCleanWorkspace\sample2 from article.json"));

            var formatedHtml = System.Xml.Linq.XElement.Parse(html).ToString();
        }
    }
}
