using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Businesses.Dto;
using Businesses.Interfaces;
using Businesses.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ArticleTag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleTaggedRecordRepository _repository;

        public ArticleController(IArticleTaggedRecordRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("DistributeArticle")]
        [SwaggerResponse(200, "输出审核文章模型", typeof(JsonResponseBase<ArticleDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> DistributeArticle(long userid)
        {
            var article = await _repository.GetArticleAsync(userid);
            return Ok(article);
        }
    }
}
