using Entity.Interfaces;

namespace Deepbio.Domain.Entities.ArticleTagAggregateRoot
{
    /// <summary>
    /// 标记实体表
    /// </summary>
    /// <remarks>Tag 模块</remarks>
    public class TagEntitiy : EntityBase<long>, IAggregateRoot
    {
        /// <summary>
        /// 父级ID
        /// </summary>
        public long PID { get; set; }

        public string Name { get; set; }
    }
}
