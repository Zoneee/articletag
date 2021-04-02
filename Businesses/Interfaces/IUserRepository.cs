using System.Threading.Tasks;
using Businesses.ViewModels.Requsets;
using Deepbio.ApplicationCore.ResearcherDbUser.Query;
using Entity.Entities;

namespace Businesses.Interfaces
{
    public interface IUserRepository
    {
        Task<UserLoginResponse> LoginAsync(string email, string password);
    }
}
