using System;

namespace Businesses.Dto
{
    public class AuditRecordDto
    {
        public string ID { get; set; }

        public string Remark { get; set; }

        public DateTime RecordTime { get; set; }

        public bool Review { get; set; }
    }
}
