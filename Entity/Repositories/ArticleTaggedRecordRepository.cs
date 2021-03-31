using Entity.Entities;
using FreeSql;

namespace Entity.Repositories
{
    /// <summary>
    /// 文献标记记录表
    /// </summary>
    public class ArticleTaggedRecordRepository : BaseRepository<ArticleTaggedRecord, long>
    {
        public ArticleTaggedRecordRepository(IFreeSql freeSql) : base(freeSql, null)
        {
        }
    }
}
