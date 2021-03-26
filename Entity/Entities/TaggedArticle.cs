using Deepbio.Domain.Enum;
using Entity.Interfaces;

namespace Deepbio.Domain.Entities.ArticleTagAggregateRoot
{
    /// <summary>
    /// 标记文章表
    /// </summary>
    /// <remarks>Tag 模块</remarks>
    public class TaggedArticle : EntityBase<long>, IAggregateRoot
    {
        /// <summary>
        /// 操作员ID
        /// </summary>
        public long OperatorID { get; set; }

        /// <summary>
        /// 已格式化的文章ID
        /// </summary>
        public long ArticleID { get; set; }

        /// <summary>
        /// 流水号。为多人任务服务
        /// </summary>
        public long TaskID { get; set; }

        /// <summary>
        /// 包含HTML的已标记的正文
        /// </summary>
        public string TaggedContent { get; set; }

        public TagArticleStatusEnum Status { get; set; }
    }
}
