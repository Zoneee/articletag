using System.Threading.Tasks;
using Businesses.ViewModels.Requsets;

namespace Businesses.Interfaces
{
    public interface IAuditRecordRepository
    {
        Task<bool> AuditArticleAsync(AuditArticleRequest article);
    }
}
