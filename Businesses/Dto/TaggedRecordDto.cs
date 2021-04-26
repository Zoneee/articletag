using System;
using System.Collections.Generic;
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
        public string ID { get; set; }

        /// <summary>
        /// 已格式化的文章ID
        /// </summary>
        public string CleanedArticleID { get; set; }

        /// <summary>
        /// 流水号。为多人任务服务
        /// </summary>
        public string TaskID { get; set; }

        public TagArticleStatusEnum Status { get; set; }
        public string StatusRemark => Status.ToDescriptionOrString();

        public DateTime LastChangeTime { get; set; }

        public TaggerDto Tagger { get; set; }
        public Auditor Auditor { get; set; }
        public ICollection<AuditRecord> AuditRecords { get; set; }
        public bool Review { get; set; }
    }

    public class Auditor
    {
        public string ID { get; set; }

        public string Name { get; set; }
    }

    public class Tag
    {
        public string ID { get; set; }

        public string Name { get; set; }

        //public string Attribute { get; set; }
        public string Color { get; set; }
    }
}
