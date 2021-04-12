using System.Threading.Tasks;
using Deepbio.ApplicationCore.ResearcherDbUser.Query;

namespace Businesses.Interfaces
{
    public interface IUserRepository
    {
        Task<UserLoginResponse> LoginAsync(string email, string password);
    }
}
