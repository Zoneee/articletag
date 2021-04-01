using System.Threading.Tasks;
using Businesses.Dto;

namespace Businesses.Interfaces
{
    public interface IArticleTaggedRecordRepository
    {
        Task<ArticleDto> GetArticleAsync(long userid);
    }
}
