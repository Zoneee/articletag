using Entity.Entities;
using FreeSql;

namespace Businesses.Repositories
{
    /// <summary>
    /// 标记实体表
    /// </summary>
    public class TagEntitiyRepository : BaseRepository<TagEntitiy, long>
    {
        public TagEntitiyRepository(IFreeSql freeSql) : base(freeSql, null)
        {
        }
    }
}
