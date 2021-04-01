using System;
using System.Threading.Tasks;
using Businesses.Interfaces;
using Businesses.ViewModels.Requsets;
using Entity.Entities;
using FreeSql;

namespace Businesses.Repositories
{
    public class AuditRecordRepository
        : BaseRepository<AuditRecord, long>,
        IAuditRecordRepository
    {
        public AuditRecordRepository(IFreeSql freeSql)
        : base(freeSql, null)
        {
        }

        /// <summary>
        /// 审核文章
        /// </summary>
        public async Task<bool> AuditArticleAsync(AuditArticleRequest article)
        {
            var record = await this.Orm.Select<ArticleTaggedRecord>()
                    .Where(s => s.ID == article.ID)
                    .ToOneAsync(s => new AuditRecord()
                    {
                        TaggedRecordID = s.ID,
                        CleanedArticleID = s.CleanedArticleID,
                        TaskID = s.TaskID,
                        TaggerID = s.UserID,
                        AuditorID = s.AdminID,
                        Status = article.Status,
                        Remark = article.Remark,
                        RecordTime = DateTime.Now,
                    });

            return await this.InsertAsync(record) != null;
        }
    }
}
