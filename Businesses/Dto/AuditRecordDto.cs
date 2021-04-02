using System;

namespace Businesses.Dto
{
    public class AuditRecordDto
    {
        public long ID { get; set; }
        public string Remark { get; set; }
        public DateTime RecordTime { get; set; }
    }
}
