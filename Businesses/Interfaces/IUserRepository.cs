using System.Threading.Tasks;
using Businesses.ViewModels.Responses;
using Entity.Entities;
using FreeSql;

namespace Businesses.Interfaces
{
    public interface IUserRepository : IBaseRepository<User, long>
    {
        Task<UserLoginResponse> LoginAsync(string email, string password);

        Task<bool> UpdateUserInfoAsync(User user);
    }
}
