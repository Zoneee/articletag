using System;
using Entity.Interfaces;

namespace Deepbio.Domain.Entities.ArticleTagAggregateRoot
{
    /// <summary>
    /// 原文表
    /// 由爬虫导入
    /// </summary>
    /// <remarks>Tag 模块</remarks>
    public class OriginalArticle : EntityBase<long>, IAggregateRoot
    {
        public string Content { get; set; }
        public DateTime ImportDate { get; set; }
        public TagContentTypeEnum ContentType { get; set; }
    }
}
