﻿using Deepbio.Domain.Enum;
using Entity.Interfaces;
using FreeSql.DataAnnotations;

namespace Deepbio.Domain.Entities.ArticleTagAggregateRoot
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
        public string UserName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
