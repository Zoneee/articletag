using System;
using System.Threading.Tasks;
using Businesses.Dto;
using Deepbio.ApplicationCore.ResearcherDbUser.Query;

namespace Businesses.Interfaces
{
    public interface IUserRepository
    {
        Task<TaggerDto> GetTaggerByArticleTaggedRecordIdAsync(long recordId);

        Task<WorkloadDto> GetWorkloadAsync(DateTime? date);

        Task<UserLoginResponse> LoginAsync(string email, string password);
    }
}
