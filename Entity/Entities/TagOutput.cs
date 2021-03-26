using Entity.Interfaces;

namespace Deepbio.Domain.Entities.ArticleTagAggregateRoot
{
    public class TagOutput : EntityBase<long>, IAggregateRoot
    {
        public long ArticleID { get; set; }
        public long TaggedID { get; set; }

        /// <summary>
        /// 标记实体名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 被标记内容文本
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 被标记内容距离文章第一个字符的起始位置
        /// </summary>
        public long Start { get; set; }

        /// <summary>
        /// 被标记内容距离文章第一个字符的结束位置
        /// </summary>
        public long End { get; set; }

        /// <summary>
        /// 表示实体的属性
        /// </summary>
        public string Attribute { get; set; }
    }
}
