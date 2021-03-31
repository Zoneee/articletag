using Entity.Entities;
using FreeSql;

namespace Entity.Repositories
{
    /// <summary>
    /// 已清洗文献表
    /// </summary>
    public class CleanedArticleRepository : BaseRepository<CleanedArticle, long>
    {
        public CleanedArticleRepository(IFreeSql freeSql) : base(freeSql, null)
        {
        }
    }
}
