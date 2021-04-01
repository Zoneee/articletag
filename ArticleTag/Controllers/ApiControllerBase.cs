using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace ArticleTag.Controllers
{
    public class ApiControllerBase: ControllerBase
    {
        protected long CurrentUserId
        {
            get
            {
                var claims = (this.User?.Identity as ClaimsIdentity) ?? throw new UnauthorizedAccessException();
                var userId = claims?.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier)?.Value;
                return Convert.ToInt64(userId);
            }
        }
    }
}
