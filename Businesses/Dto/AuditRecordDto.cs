using System;
using System.Text.Json.Serialization;
using Businesses.JsonConverters;

namespace Businesses.Dto
{
    public class AuditRecordDto
    {
        [JsonConverter(typeof(LongConverter))]
        public long ID { get; set; }

        public string Remark { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime RecordTime { get; set; }
    }
}
