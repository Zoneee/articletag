using System.Collections.Generic;

namespace Businesses.Dto
{
    public class WorkloadDto
    {
        public ICollection<WorkloadItem> Collection { get; set; }
        public string Total { get; set; }
    }

    public class WorkloadItem
    {
        public string ID { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Untagged { get; set; }
        public string Tagging { get; set; }
        public string Tagged { get; set; }
        public string Unaudited { get; set; }
        public string Audited { get; set; }
        public string Unsanctioned { get; set; }
        public string Unavail { get; set; }
        public string PreProcessed { get; set; }
        public string Count => (long.Parse(Untagged) + long.Parse(Tagging) + long.Parse(Tagged) + long.Parse(Unaudited) + long.Parse(Audited) + long.Parse(Unsanctioned) + long.Parse(Unavail) + long.Parse(PreProcessed)).ToString();
    }
}
