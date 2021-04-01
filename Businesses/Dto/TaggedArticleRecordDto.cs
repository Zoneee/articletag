using System;
using System.Collections.Generic;
using Deepbio.Domain.Enum;

namespace Businesses.Dto
{
    /// <summary>
    /// 标记文献记录DTO
    /// </summary>
    public class TaggedArticleRecordDto
    {
        public long ID { get; set; }

        /// <summary>
        /// 已格式化的文章ID
        /// </summary>
        public long CleanedArticleID { get; set; }

        /// <summary>
        /// 流水号。为多人任务服务
        /// </summary>
        public long TaskID { get; set; }

        public TagArticleStatusEnum Status { get; set; }
        public DateTime StatusChangeTime { get; set; }

        public Tagger Tagger { get; set; }
        public Manager Manager { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }

    public class Tagger
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Manager
    {
        public long ID { get; set; }
        public string Name { get; set; }
    }

    public class Tag
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
