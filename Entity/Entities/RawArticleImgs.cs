using Deepbio.Domain.Entities;
using Entity.Interfaces;
using FreeSql.DataAnnotations;

namespace Entity.Entities
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
