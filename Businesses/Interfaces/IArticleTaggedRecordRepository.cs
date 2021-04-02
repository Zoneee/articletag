using System.Collections.Generic;
using System.Threading.Tasks;
using Businesses.Dto;
using Businesses.ViewModels.Requsets;

namespace Businesses.Interfaces
{
    public interface IArticleTaggedRecordRepository
    {
        Task<bool> AuditArticleAsync(AuditArticleRequest article);
        Task<bool> CheckCanAuditAsync(long articleId);
        Task<bool> CheckCanEditAsync(long articleId);
        Task<ArticleDto> GetArticleAsync(long id);
        Task<ArticleDto> GetArticleByTaggerIdAsync(long taggerId);
        Task<TaggedRecordDto> GetArticlesByPagingAsync(int page, int size);
        Task<bool> SaveTaggedRecordAsync(ArticleRecordRequest record);
        Task<bool> SubmitAuditAsync(long articleId);
    }
}
