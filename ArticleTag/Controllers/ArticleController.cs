using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Businesses.Dto;
using Businesses.Interfaces;
using Businesses.ViewModels;
using Businesses.ViewModels.Requsets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace ArticleTag.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ArticleController : ApiControllerBase
    {
        private readonly IArticleTaggedRecordRepository _articleRecordRepo;
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(
            IArticleTaggedRecordRepository articleRecordRepo,
            ILogger<ArticleController> logger)
        {
            _articleRecordRepo = articleRecordRepo;
            _logger = logger;
        }

        [HttpPost("DistributeArticle")]
        [SwaggerResponse(200, "标记员获取文献", typeof(JsonResponseBase<ArticleDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> DistributeArticle(long taggerId)
        {
            var response = JsonResponseBase<ArticleDto>.CreateDefault();
            try
            {
                var article = await _articleRecordRepo.GetArticleByTaggerIdAsync(taggerId);
                response.Result = article;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMsg = ex.Message;
                response.ErrorCode = HttpCodeEnum.Error;
                _logger.LogError("标记员获取文献异常！", ex);
                return Ok(response);
            }
        }

        [HttpPost("CheckCanEdit")]
        [SwaggerResponse(200, "输出文献可编辑标识", typeof(JsonResponseBase<bool, IDictionary<string, string[]>>))]
        public async Task<IActionResult> CheckCanEdit(long articleId)
        {
            var response = JsonResponseBase<bool>.CreateDefault();
            try
            {
                response.Result = await _articleRecordRepo.CheckCanEditAsync(articleId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMsg = ex.Message;
                response.ErrorCode = HttpCodeEnum.Error;
                _logger.LogError("输出文献可编辑标识异常！", ex);
                return Ok(response);
            }
        }

        [HttpPost("CheckCanAudit")]
        [SwaggerResponse(200, "输出文献可审核标识", typeof(JsonResponseBase<bool, IDictionary<string, string[]>>))]
        public async Task<IActionResult> CheckCanAudit(long articleId)
        {
            var response = JsonResponseBase<bool>.CreateDefault();
            try
            {
                response.Result = await _articleRecordRepo.CheckCanAuditAsync(articleId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMsg = ex.Message;
                response.ErrorCode = HttpCodeEnum.Error;
                _logger.LogError("输出文献可审核标识异常！", ex);
                return Ok(response);
            }
        }

        [HttpPost("SaveTaggedRecord")]
        [SwaggerResponse(200, "保存标记员标记记录", typeof(JsonResponseBase<bool, IDictionary<string, string[]>>))]
        public async Task<IActionResult> SaveTaggedRecord(ArticleRecordRequest record)
        {
            var response = JsonResponseBase<bool>.CreateDefault();
            try
            {
                response.Result = await _articleRecordRepo.SaveTaggedRecordAsync(record);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMsg = ex.Message;
                response.ErrorCode = HttpCodeEnum.Error;
                _logger.LogError("保存标记员标记记录异常！", ex);
                return Ok(response);
            }
        }

        [HttpPost("SubmitAudit")]
        [SwaggerResponse(200, "标记员提交审核", typeof(JsonResponseBase<bool, IDictionary<string, string[]>>))]
        public async Task<IActionResult> SubmitAudit(long articleId)
        {
            var response = JsonResponseBase<bool>.CreateDefault();
            try
            {
                response.Result = await _articleRecordRepo.SubmitAuditAsync(articleId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMsg = ex.Message;
                response.ErrorCode = HttpCodeEnum.Error;
                _logger.LogError("标记员提交审核异常！", ex);
                return Ok(response);
            }
        }

        [HttpPost("SetUnavailArticle")]
        [SwaggerResponse(200, "标记员提交无效文章", typeof(JsonResponseBase<bool, IDictionary<string, string[]>>))]
        public async Task<IActionResult> SetUnavailArticle(long articleId)
        {
            var response = JsonResponseBase<bool>.CreateDefault();
            try
            {
                response.Result = await _articleRecordRepo.SetUnavailArticleAsync(articleId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMsg = ex.Message;
                response.ErrorCode = HttpCodeEnum.Error;
                _logger.LogError("标记员提交无效文章异常！", ex);
                return Ok(response);
            }
        }

        [HttpPost("PagingAritcle")]
        [SwaggerResponse(200, "分页查看标记记录", typeof(JsonResponseBase<TaggedRecordDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> PagingSearchTaggedRecord(int page, int size)
        {
            var response = JsonResponseBase<TaggedRecordDto>.CreateDefault();
            try
            {
                var articles = await _articleRecordRepo.GetArticlesByPagingAsync(CurrentUserId, page, size);
                response.Result = articles;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMsg = ex.Message;
                response.ErrorCode = HttpCodeEnum.Error;
                _logger.LogError("分页查看标记记录异常！", ex);
                return Ok(response);
            }
        }

        [HttpPost("SearchArticle")]
        [SwaggerResponse(200, "查看文章", typeof(JsonResponseBase<ArticleDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> SearchArticle(long articleId)
        {
            var response = JsonResponseBase<ArticleDto>.CreateDefault();
            try
            {
                var article = await _articleRecordRepo.GetArticleAsync(articleId);
                response.Result = article;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMsg = ex.Message;
                response.ErrorCode = HttpCodeEnum.Error;
                _logger.LogError("查看文章异常！", ex);
                return Ok(response);
            }
        }

        [HttpPost("AuditArticle")]
        [SwaggerResponse(200, "审核文章", typeof(JsonResponseBase<bool, IDictionary<string, string[]>>))]
        public async Task<IActionResult> AuditArticle(AuditArticleRequest audit)
        {
#if DEBUG
            audit.AuditorID = 2;
#endif
            var response = JsonResponseBase<bool>.CreateDefault();
            try
            {
                response.Result = await _articleRecordRepo.AuditArticleAsync(audit);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMsg = ex.Message;
                response.ErrorCode = HttpCodeEnum.Error;
                _logger.LogError("审核文章异常！", ex);
                return Ok(response);
            }
        }
    }
}
