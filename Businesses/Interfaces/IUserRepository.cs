using System.Threading.Tasks;
using Businesses.Dto;
using Deepbio.ApplicationCore.ResearcherDbUser.Query;

namespace Businesses.Interfaces
{
    public interface IUserRepository
    {
        Task<TaggerDto> GetTaggerByArticleTaggedRecordIdAsync(long recordId);

        Task<UserLoginResponse> LoginAsync(string email, string password);
    }
}
