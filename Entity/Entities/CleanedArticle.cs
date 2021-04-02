using System;
using Deepbio.Domain.Entities;
using Entity.Interfaces;
using FreeSql.DataAnnotations;

namespace Entity.Entities
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
