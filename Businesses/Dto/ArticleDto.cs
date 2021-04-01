using System.Collections.Generic;

namespace Businesses.Dto
{
    public class ArticleDto
    {
        public long ID { get; set; }
        public string Content { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
