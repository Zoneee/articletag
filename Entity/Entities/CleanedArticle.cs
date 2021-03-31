using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deepbio.Domain.Entities;
using Entity.Interfaces;
using FreeSql.DataAnnotations;

namespace CleanRawArticleTool
{
    public class CleanedArticle : EntityBase<long>, IAggregateRoot
    {
        public long RawArticleID { get; set; }
        [Column(DbType = "varchar(max)")]
        public string CleanedContent { get; set; }
        [Column(DbType = "varchar(max)")]
        public string PlainArticleText { get; set; }
        public DateTime CleanTime { get; set; }
    }
}
