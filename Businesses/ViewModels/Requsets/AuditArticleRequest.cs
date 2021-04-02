using Entity.Enum;

namespace Businesses.ViewModels.Requsets
{
    public class AuditArticleRequest
    {
        public string ID { get; set; }
        public TagArticleStatusEnum Status { get; set; }
        public string Remark { get; set; }
        public long AuditorID { get; set; }
    }
}
