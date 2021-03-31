using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deepbio.Domain.Entities;
using Entity.Interfaces;
using FreeSql.DataAnnotations;

namespace CleanRawArticleTool
{
    public class RawArticleImgs : EntityBase<long>, IAggregateRoot
    {
        public long ArticleID { get; set; }
        [Column(DbType = "varchar(1024)")]
        public string ImgNumber { get; set; }
        [Column(DbType = "varchar(1024)")]
        public string ImgUrl { get; set; }
        [Column(DbType = "varchar(1024)")]
        public string LocalImgPath { get; set; }
    }
}
