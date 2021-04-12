using System;
using Deepbio.Domain.Entities;
using Entity.Enum;
using Entity.Interfaces;
using FreeSql.DataAnnotations;

namespace Entity.Entities
{
    public class RawArticle : EntityBase<long>, IAggregateRoot
    {
        [Column(DbType = "varchar(max)")]
        public string RawContent { get; set; }

        public TagContentFormatEnum? ContentFormat { get; set; }
        public string BatchName { get; set; }
        public DateTime ImportTime { get; set; }
        public string DOI { get; set; }
    }
}
