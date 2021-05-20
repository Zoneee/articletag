using System;
using System.Threading.Tasks;
using Businesses.Dto;
using Businesses.Exceptions;
using Businesses.Interfaces;
using Deepbio.ApplicationCore.ResearcherDbUser.Query;
using Entity.Entities;
using Entity.Enum;
using FreeSql;

namespace Businesses.Repositories
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserRepository
        : BaseRepository<User, long>,
        IUserRepository
    {
        public UserRepository(IFreeSql freeSql) : base(freeSql, null)
        {
        }

        public async Task<UserLoginResponse> LoginAsync(string email, string password)
        {
            var pwdSalt = password;

            var user = await this.Select
                 .Where(s => s.Email == email && s.Password == pwdSalt)
                 .ToOneAsync();
            if (user == null)
            {
                throw new WarnException("您的用户名或密码不正确！");
            }

            user.LastLoginTime = DateTime.Now;
            await this.UpdateAsync(user);

            var userVm = new UserLoginResponse()
            {
                UserId = user.ID,
                UserName = user.NickName,
                Email = user.Email,
                Role = user.Role
            };

            return userVm;
        }

        public async Task<TaggerDto> GetTaggerByArticleTaggedRecordIdAsync(long recordId)
        {
            var recordReps = this.Orm.GetRepository<ArticleTaggedRecord>();

            var tagger = await Select
                .InnerJoin<ArticleTaggedRecord>((u, r) => u.ID == r.UserID)
                .Where<ArticleTaggedRecord>(s => s.ID == recordId)
                .ToOneAsync(s => new TaggerDto()
                {
                    ID = s.ID.ToString(),
                    Email = s.Email,
                    Name = s.NickName
                });

            return tagger;
        }

        public async Task<WorkloadDto> GetWorkloadAsync(DateTime? date)
        {
            var workloads = await Orm.Select<User, ArticleTaggedRecord>()
                       .InnerJoin((u, r) => u.ID == r.UserID)
                       .Where((u, r) => r.Status == TagArticleStatusEnum.Unaudited)
                       .WhereIf(date != null, "DATEDIFF(DAY,CONVERT(VARCHAR(10),@date,120),LastChangeTime) = 0", date)
                       .GroupBy((u, r) => u.ID)
                       .Page(0, 10)
                       .Count(out var total)
                       .ToListAsync((u) => new WorkloadItem()
                       {
                           ID = u.Key,
                           Email = u.Max(u.Value.Item1.Email),
                           Count = SqlExt.DistinctCount(u.Value.Item2.ID)
                       });

            return new WorkloadDto()
            {
                Collection = workloads,
                Total = total
            };
        }
    }
}
