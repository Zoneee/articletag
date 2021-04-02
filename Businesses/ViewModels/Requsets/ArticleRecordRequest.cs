using System.Collections.Generic;
using Businesses.Dto;

namespace Businesses.ViewModels.Requsets
{
    public class ArticleRecordRequest
    {
        public string ID { get; set; }
        public string TaggedContent { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
