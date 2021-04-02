using System;
using System.Threading.Tasks;
using Businesses.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ArticleTag.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private ILogger<ApiExceptionFilterAttribute> _logger = null;

        public ApiExceptionFilterAttribute(ILogger<ApiExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
            var response = JsonResponseBase<dynamic>.CreateDefault();
            response.Success = false;

            if (context.Exception is UnauthorizedAccessException)
            {
                context.HttpContext.Response.StatusCode = 401;
                response.HttpCode = 401;
                response.ErrorMsg = "Unauthorized Access";
                _logger.LogError("User unauthorized");
            }
            else
            {
                _logger.LogError(context.Exception, context.Exception.Message);
                response.ErrorMsg = context.Exception.Message;
            }

            context.Result = new JsonResult(response);
            await Task.CompletedTask;
        }
    }
}
