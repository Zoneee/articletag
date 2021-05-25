using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArticleTag.Models;
using Businesses.Dto;
using Businesses.Interfaces;
using Businesses.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace ArticleTag.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserCenterController : ApiControllerBase
    {
        private readonly IUserRepository _user;
        private readonly ILogger<UserCenterController> _logger;

        public UserCenterController(IUserRepository user,
            ILogger<UserCenterController> logger)
        {
            _user = user;
            _logger = logger;
        }

        [HttpPost("workload")]
        [SwaggerResponse(200, "根据日期查询用户工作量", typeof(JsonResponseBase<WorkloadDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> GetWorkload(WorkloadVm workload)
        {
            var response = JsonResponseBase<WorkloadDto>.CreateDefault();
            try
            {
                var result = await _user.GetWorkloadAsync(workload.StartDate, workload.EndDate, workload.ArticleStatus, workload.PageIndex, workload.PageSize);
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorCode = HttpCodeEnum.Error;
                _logger.LogError($"根据日期查询用户工作量异常！", ex);
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
                response.Result = await _user.UpdateUserInfoAsync(new Entity.Entities.User()
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
