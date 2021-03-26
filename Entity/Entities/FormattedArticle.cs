using Entity.Interfaces;

namespace Deepbio.Domain.Entities.ArticleTagAggregateRoot
{
    /// <summary>
    /// 格式化文章
    /// </summary>
    /// <remarks>Tag 模块</remarks>
    public class FormattedArticle : EntityBase<long>, IAggregateRoot
    {
        public long OriginalArticleID { get; set; }
        public string FormattedContent { get; set; }
    }
}
