using System.Threading.Tasks;
using Businesses.ViewModels.Responses;
using Entity.Entities;

namespace Businesses.Interfaces
{
    public interface IUserRepository
    {
        Task<UserLoginResponse> LoginAsync(string email, string password);

        Task<bool> UpdateUserInfoAsync(User user);
    }
}
