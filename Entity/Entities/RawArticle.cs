using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanRawArticleTool.Models;
using Deepbio.Domain.Entities;
using Entity.Interfaces;
using FreeSql.DataAnnotations;

namespace CleanRawArticleTool
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
