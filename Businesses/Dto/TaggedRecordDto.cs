using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Businesses.JsonConverters;
using Entity.Entities;
using Entity.Enum;

namespace Businesses.Dto
{
    /// <summary>
    /// 标记记录DTO
    /// </summary>
    public class TaggedRecordDto
    {
        public IEnumerable<TaggedRecord> Records { get; set; }
        public long Total { get; set; }
    }

    public class TaggedRecord
    {
        [JsonConverter(typeof(LongConverter))]
        public long ID { get; set; }

        /// <summary>
        /// 已格式化的文章ID
        /// </summary>
        [JsonConverter(typeof(LongConverter))]
        public long CleanedArticleID { get; set; }

        /// <summary>
        /// 流水号。为多人任务服务
        /// </summary>
        [JsonConverter(typeof(LongConverter))]
        public long TaskID { get; set; }

        public TagArticleStatusEnum Status { get; set; }
        public string StatusRemark => Status.ToDescriptionOrString();

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastChangeTime { get; set; }

        public Tagger Tagger { get; set; }
        public Auditor Auditor { get; set; }
        public ICollection<AuditRecord> AuditRecords { get; set; }
    }

    public class Tagger
    {
        [JsonConverter(typeof(LongConverter))]
        public long ID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Auditor
    {
        [JsonConverter(typeof(LongConverter))]
        public long ID { get; set; }

        public string Name { get; set; }
    }

    public class Tag
    {
        [JsonConverter(typeof(LongConverter))]
        public long ID { get; set; }

        public string Name { get; set; }

        //public string Attribute { get; set; }
        public string Color { get; set; }
    }
}
