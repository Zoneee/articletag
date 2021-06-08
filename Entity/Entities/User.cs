using System;
using Deepbio.Domain.Entities;
using Entity.Enum;
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

        /// <summary>
        /// 每日可跳过次数
        /// </summary>
        public int CanSkipTimesPerDay { get; set; }

        /// <summary>
        /// 用户信息版本
        /// （用来使JWT过期）
        /// </summary>
        public int Version { get; set; }
    }
}
