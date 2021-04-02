using System.Collections.Generic;
using System.Text.Json.Serialization;
using Businesses.JsonConverters;

namespace Businesses.Dto
{
    public class ArticleDto
    {
        public string ID { get; set; }

        public string Content { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
