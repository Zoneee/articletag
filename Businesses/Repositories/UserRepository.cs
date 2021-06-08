using System;
using System.Threading.Tasks;
using Businesses.Exceptions;
using Businesses.Interfaces;
using Businesses.ViewModels.Responses;
using Entity.Entities;
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
                Role = user.Role,
                CanSkipTimesPerDay = user.CanSkipTimesPerDay,
                Version = user.Version,
            };

            return userVm;
        }

        public async Task<bool> UpdateUserInfoAsync(User user)
        {
            var model = await Select.Where(s => s.ID == user.ID).ToOneAsync();
            if (model == null)
            {
                return false;
            }

            model.NickName = user.NickName;
            return await UpdateAsync(model) > 0;
        }
    }
}
