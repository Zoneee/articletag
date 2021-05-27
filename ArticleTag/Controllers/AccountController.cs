﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ArticleTag.Helpers;
using ArticleTag.Models;
using Businesses.Exceptions;
using Businesses.Interfaces;
using Businesses.ViewModels;
using Businesses.ViewModels.Requsets;
using Deepbio.ApplicationCore.ResearcherDbUser.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace ArticleTag.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AccountController : ApiControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<AccountController> _logger;
        private readonly AppSettings _appSettings;

        public AccountController(IUserRepository repository
            , IOptions<AppSettings> appSettings
            , ILogger<AccountController> logger)
        {
            _repository = repository;
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        [HttpPost("Login"), AllowAnonymous]
        [SwaggerResponse(200, "用户登录", typeof(JsonResponseBase<UserLoginResponse, IDictionary<string, string[]>>))]
        public async Task<IActionResult> Login(UserLoginVm loginUser)
        {
            var response = JsonResponseBase<UserLoginResponse>.CreateDefault();
            try
            {
                var user = await _repository.LoginAsync(loginUser.LoginName, loginUser.Password);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                response.Result = user;
            }
            catch (WarnException warn)
            {
                response.Success = false;
                response.ErrorCode = HttpCodeEnum.Warn;
                response.ErrorMsg = warn.Message;
                _logger.LogWarning($"登录失败：{loginUser.LoginName}", warn);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorCode = HttpCodeEnum.Error;
                _logger.LogError($"登录异常：{loginUser.LoginName}", ex);
            }

            return Ok(response);
        }

        [HttpPut("user/info")]
        [SwaggerResponse(200, "更新用户信息", typeof(JsonResponseBase<bool, IDictionary<string, string[]>>))]
        public async Task<IActionResult> Update(UserVm user)
        {
            var response = JsonResponseBase<bool, IDictionary<string, string[]>>.CreateDefault();

            try
            {
                response.Result = await _repository.UpdateUserInfoAsync(new Entity.Entities.User()
                {
                    ID = long.Parse(user.ID),
                    NickName = user.NickName
                });
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Result = false;
                response.HttpCode = 500;
                response.ErrorMsg = "更新用户信息异常！";
                _logger.LogError(ex, "更新用户信息异常！");
            }

            return Ok(response);
        }
    }
}
