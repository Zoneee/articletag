using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetWorkload(DateTime? date)
        {
            var response = JsonResponseBase<WorkloadDto>.CreateDefault();
            try
            {
                var result = await _user.GetWorkloadAsync(date);
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
    }
}
