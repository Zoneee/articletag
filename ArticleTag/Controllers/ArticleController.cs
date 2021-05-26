using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArticleTag.Models;
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
        private readonly IArticleTaggedRecordRepository _repository;
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(
            IArticleTaggedRecordRepository articleRecordRepo,
            ILogger<ArticleController> logger)
        {
            _repository = articleRecordRepo;
            _logger = logger;
        }

        [HttpPost("DistributeArticle")]
        [SwaggerResponse(200, "标记员获取文献", typeof(JsonResponseBase<ArticleDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> DistributeArticle(long taggerId)
        {
            var response = JsonResponseBase<ArticleDto>.CreateDefault();
            try
            {
                var article = await _repository.GetArticleByTaggerIdAsync(taggerId);
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
                response.Result = await _repository.CheckCanEditAsync(articleId);
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
                response.Result = await _repository.CheckCanAuditAsync(articleId);
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
                response.Result = await _repository.SaveTaggedRecordAsync(record);
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
                response.Result = await _repository.SubmitAuditAsync(articleId);
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
                response.Result = await _repository.SetUnavailArticleAsync(articleId);
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

        [HttpPost("SearchArticle")]
        [SwaggerResponse(200, "查看文章", typeof(JsonResponseBase<ArticleDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> SearchArticle(long articleId)
        {
            var response = JsonResponseBase<ArticleDto>.CreateDefault();
            try
            {
                var article = await _repository.GetArticleAsync(articleId);
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
            var response = JsonResponseBase<bool>.CreateDefault();
            try
            {
                response.Result = await _repository.AuditArticleAsync(audit);
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

        [HttpPost("SetReviewArticle")]
        [SwaggerResponse(200, "设置文章为综述文章", typeof(JsonResponseBase<bool, IDictionary<string, string[]>>))]
        public async Task<IActionResult> SetReviewArticle(long articleId, bool review)
        {
            var response = JsonResponseBase<bool>.CreateDefault();
            try
            {
                response.Result = await _repository.SetReviewArticleAsync(articleId, review);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMsg = ex.Message;
                response.ErrorCode = HttpCodeEnum.Error;
                _logger.LogError("设置文章为综述文章异常！", ex);
                return Ok(response);
            }
        }

        [HttpPost("GetTaggersCanAuditArticle")]
        [SwaggerResponse(200, "根据标记员获取可审核的文献", typeof(JsonResponseBase<ArticleDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> GetTaggersCanAuditArticle(long taggerId)
        {
            var response = JsonResponseBase<ArticleDto>.CreateDefault();
            try
            {
                response.Result = await _repository.GetCanAuditArticleAsync(taggerId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMsg = ex.Message;
                response.ErrorCode = HttpCodeEnum.Error;
                _logger.LogError("根据标记员获取可审核的文献异常！", ex);
                return Ok(response);
            }
        }

        [HttpPost("PagingAritcle")]
        [SwaggerResponse(200, "分页查看标记记录", typeof(JsonResponseBase<TaggedRecordDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> PagingSearchTaggedRecord(TaggedRecordPagerVm vm)
        {
            var response = JsonResponseBase<TaggedRecordDto>.CreateDefault();
            try
            {
                var articles = await _repository
                    .GetArticlesByPagingAsync(CurrentUserId, vm.Page, vm.Size,
                    vm.Status, vm.Review, vm.TaggerNickName);
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

        [HttpPost("workload")]
        [SwaggerResponse(200, "根据日期查询用户工作量", typeof(JsonResponseBase<WorkloadDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> GetWorkload(WorkloadVm workload)
        {
            var response = JsonResponseBase<WorkloadDto>.CreateDefault();
            try
            {
                var result = await _repository.GetWorkloadAsync(workload.StartDate, workload.EndDate, workload.PageIndex, workload.PageSize);
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

        [HttpPost("GetTaggerInfoByArticleTaggedRecordId")]
        [SwaggerResponse(200, "根据文献标记记录获取标记员信息", typeof(JsonResponseBase<TaggerDto, IDictionary<string, string[]>>))]
        public async Task<IActionResult> GetTaggerInfoByArticleTaggedRecordId(long recordId)
        {
            var response = JsonResponseBase<TaggerDto>.CreateDefault();
            try
            {
                response.Result = await _repository.GetTaggerByArticleTaggedRecordIdAsync(recordId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMsg = ex.Message;
                response.ErrorCode = HttpCodeEnum.Error;
                _logger.LogError("根据文献标记记录获取标记员信息异常！", ex);
                return Ok(response);
            }
        }
    }
}
