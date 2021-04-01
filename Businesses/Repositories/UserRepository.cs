using Entity.Entities;
using FreeSql;

namespace Businesses.Repositories
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserRepository : BaseRepository<User, long>
    {
        public UserRepository(IFreeSql freeSql) : base(freeSql, null)
        {
        }
    }
}
