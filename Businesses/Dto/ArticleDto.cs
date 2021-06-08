using System.Collections.Generic;
using System.Text.Json.Serialization;
using Entity.Enum;

namespace Businesses.Dto
{
    public class ArticleDto
    {
        public string ID { get; set; }

        public string Content { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public bool Review { get; set; }
        public TagArticleStatusEnum Status { get; set; }
        /// <summary>
        /// 最后一次审核备注
        /// </summary>
        [JsonPropertyName("remark")]
        public string LastRemark { get; set; }
    }
}
