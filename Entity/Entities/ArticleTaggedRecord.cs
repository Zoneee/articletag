using System;
using System.Security.Principal;
using Deepbio.Domain.Enum;
using Entity.Interfaces;
using FreeSql.DataAnnotations;

namespace Deepbio.Domain.Entities.ArticleTagAggregateRoot
{
    /// <summary>
    /// 标记文章表
    /// </summary>
    /// <remarks>Tag 模块</remarks>
    public class ArticleTaggedRecord : EntityBase<long>, IAggregateRoot
    {
        /// <summary>
        /// 标注员ID
        /// </summary>
        public long UserID { get; set; }

        public long AdminID { get; set; }

        /// <summary>
        /// 已格式化的文章ID
        /// </summary>
        public long CleanedArticleID { get; set; }

        /// <summary>
        /// 流水号。为多人任务服务
        /// </summary>
        public long TaskID { get; set; }

        /// <summary>
        /// 包含HTML的已标记的正文
        /// </summary>
        [Column(DbType = "nvarchar(max)")]
        public string TaggedContent { get; set; }

        [Column(DbType = "nvarchar(max)")]
        public string TaggedArray { get; set; }

        public TagArticleStatusEnum Status { get; set; }
        public DateTime StatusChangeTime { get; set; }
    }
}
