using System;
using Deepbio.Domain.Entities;
using Deepbio.Domain.Enum;
using Entity.Interfaces;

namespace Entity.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    /// <remarks>Tag 模块用户表</remarks>
    public class User : EntityBase<long>, IAggregateRoot
    {
        public TagRoleEnum Role { get; set; }

        /// <summary>
        /// 页面显示用
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}
