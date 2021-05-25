using System;
using System.Threading.Tasks;
using Businesses.Dto;
using Deepbio.ApplicationCore.ResearcherDbUser.Query;
using Entity.Entities;
using Entity.Enum;

namespace Businesses.Interfaces
{
    public interface IUserRepository
    {
        Task<TaggerDto> GetTaggerByArticleTaggedRecordIdAsync(long recordId);

        Task<WorkloadDto> GetWorkloadAsync(DateTime? startDate, DateTime? endDate, TagArticleStatusEnum? status, int page, int size);

        Task<UserLoginResponse> LoginAsync(string email, string password);

        Task<bool> UpdateUserInfoAsync(User user);
    }
}
