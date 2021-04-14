using System.Collections.Generic;

namespace Businesses.Dto
{
    public class ArticleDto
    {
        public string ID { get; set; }

        public string Content { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public bool Review { get; set; }
    }
}
