using System.Collections.Generic;

namespace Businesses.Dto
{
    public class WorkloadDto
    {
        public ICollection<WorkloadItem> Collection { get; set; }
        public long Total { get; set; }
    }

    public class WorkloadItem
    {
        public long ID { get; set; }
        public string Email { get; set; }
        public long Count { get; set; }
        public string NickName { get; set; }
    }
}
