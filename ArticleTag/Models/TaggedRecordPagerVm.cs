using Entity.Enum;

namespace ArticleTag.Models
{
    public class TaggedRecordPagerVm
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public bool? Review { get; set; }
        public TagArticleStatusEnum? Status { get; set; }
        public string TaggerNickName { get; set; }
    }
}
