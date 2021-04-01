using System;
using Deepbio.Domain.Entities;
using Deepbio.Domain.Enum;
using Entity.Interfaces;

namespace Entity.Entities
{
    /// <summary>
    /// 审核记录表
    /// </summary>
    public class AuditRecord : EntityBase<long>, IAggregateRoot
    {
        public long CleanedArticleID { get; set; }

        public long TaggedRecordID { get; set; }

        public long TaskID { get; set; }

        public long TaggerID { get; set; }

        public long AuditorID { get; set; }

        public TagArticleStatusEnum Status { get; set; }

        public string Remark { get; set; }

        public DateTime RecordTime { get; set; }

    }
}
