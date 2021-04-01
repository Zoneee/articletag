using System.Collections.Generic;
using System.Threading.Tasks;
using Businesses.Dto;
using Businesses.Interfaces;
using Businesses.ViewModels;
using Businesses.ViewModels.Requsets;
using Deepbio.Domain.Enum;
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
        [SwaggerResponse(200, "标记员获取文献", typeof(JsonResponseBase<ArticleDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> DistributeArticle(long userid)
        {
            var article = await _repository.GetArticleAsync(userid);
            return Ok(article);
        }

        [HttpPost("CheckCanEdit")]
        [SwaggerResponse(200, "输出文献编辑标识", typeof(JsonResponseBase<ArticleDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> CheckCanEdit(long articleId)
        {
            return Ok(await _repository.CheckCanEditAsync(articleId));
        }

        [HttpPost("SaveTaggedRecord")]
        [SwaggerResponse(200, "保存标记员标记记录", typeof(JsonResponseBase<ArticleDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> SaveTaggedRecord(ArticleRecordRequest record)
        {
            return Ok(await _repository.SaveTaggedRecordAsync(record));
        }

        [HttpPost("SubmitAudit")]
        [SwaggerResponse(200, "标记员提交审核", typeof(JsonResponseBase<ArticleDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> SubmitAudit(long articleId)
        {
            return Ok(await _repository.SubmitAuditAsync(articleId));
        }

        [HttpPost("PagingAritcle")]
        [SwaggerResponse(200, "分页查看标记记录", typeof(JsonResponseBase<ArticleDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> PagingSearchTaggedRecord(int page, int size)
        {
            var articles = _repository.GetArticlesByPagingAsync(page, size);
            return Ok(articles);
        }

        [HttpPost("SearchArticle")]
        [SwaggerResponse(200, "查看文章", typeof(JsonResponseBase<ArticleDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> SearchArticle(long articleId)
        {
            var article = await _repository.GetArticleAsync(articleId);
            return Ok(article);
        }

        [HttpPost("AuditArticle")]
        [SwaggerResponse(200, "审核文章", typeof(JsonResponseBase<ArticleDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> AuditArticle(AuditArticleRequest audit)
        {
#if DEBUG
            audit.AuditorID = 9999;
#endif

            var flag = await _repository.AuditArticleAsync(audit);

            return Ok(flag);
        }

    }
}
