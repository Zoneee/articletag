using System;
using System.Text.Json.Serialization;
using Businesses.JsonConverters;

namespace Businesses.Dto
{
    public class AuditRecordDto
    {
        public string ID { get; set; }

        public string Remark { get; set; }

        public DateTime RecordTime { get; set; }
    }
}
