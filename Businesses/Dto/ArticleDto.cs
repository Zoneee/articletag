using System;
using System.Collections.Generic;
using System.Text;

namespace Businesses.Dto
{
    public class ArticleDto
    {
        public long ID { get; set; }
        public string Content { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
