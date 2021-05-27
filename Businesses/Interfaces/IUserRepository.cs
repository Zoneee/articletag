using System.Threading.Tasks;
using Deepbio.ApplicationCore.ResearcherDbUser.Query;
using Entity.Entities;

namespace Businesses.Interfaces
{
    public interface IUserRepository
    {
        Task<UserLoginResponse> LoginAsync(string email, string password);

        Task<bool> UpdateUserInfoAsync(User user);
    }
}
