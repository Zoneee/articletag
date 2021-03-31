using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Deepbio.Domain.Entities;
using Entity.Interfaces;
using FreeSql.DataAnnotations;

namespace Entity.Entities
{
    public class ArticleTaggedOutput : EntityBase<long>, IAggregateRoot
    {
        public long TagRecordID { get; set; }
        [Column(DbType = "nvarchar(max)")]
        /// <summary>
        /// 标记实体名称
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 被标记内容距离文章第一个字符的起始位置
        /// </summary>
        public int Start { get; set; }
        /// <summary>
        /// 被标记内容距离文章第一个字符的结束位置
        /// </summary>
        public int End { get; set; }
        [Column(DbType = "nvarchar(1000)")]
        /// <summary>
        /// 表示实体的属性
        /// </summary>
        public string TagValue { get; set; }
        /// <summary>
        /// 表示实体的属性的值
        /// </summary>
        public string TagAttribute { get; set; }
        public DateTime OutTime { get; set; }
    }
}
