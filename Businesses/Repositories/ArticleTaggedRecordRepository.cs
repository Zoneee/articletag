using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Businesses.Dto;
using Businesses.Exceptions;
using Businesses.Interfaces;
using Businesses.ViewModels.Requsets;
using Entity.Entities;
using Entity.Enum;
using FreeSql;
using IdGen;
using Newtonsoft.Json;

namespace Businesses.Repositories
{
    /// <summary>
    /// 文献标记记录表
    /// </summary>
    public class ArticleTaggedRecordRepository
        : BaseRepository<ArticleTaggedRecord, long>,
        IArticleTaggedRecordRepository
    {
        private static Lazy<IdGenerator> _idGenerator = new Lazy<IdGenerator>(() => new IdGenerator(0));

        public ArticleTaggedRecordRepository(IFreeSql freeSql) : base(freeSql, null)
        {
        }

        public async Task<ArticleDto> GetArticleAsync(long id)
        {
            var article = await this.Select
                   .Where(s => s.ID == id)
                   .ToOneAsync();

            var dto = new ArticleDto()
            {
                ID = article.ID.ToString(),
                Content = article.TaggedContent,
                Tags = JsonConvert.DeserializeObject<ICollection<Tag>>(article.TaggedArray ?? "")
            };

            return dto;
        }

        public async Task<TaggedRecordDto> GetArticlesByPagingAsync(long userid, int page, int size)
        {
            var user = await this.Orm.GetRepository<User>()
                .Select
                .Where(s => s.ID == userid)
                .ToOneAsync();

            var records = await this.Select
             .WhereIf(user.Role == TagRoleEnum.Tagger, s => s.UserID == userid)
             .Page(page, size)
             .Include(s => s.Tagger)
             .Include(s => s.Manager)
             .IncludeMany(s => s.AuditRecords)
             .Count(out var total)
             .ToListAsync(s => new TaggedRecord()
             {
                 ID = s.ID.ToString(),
                 CleanedArticleID = s.CleanedArticleID.ToString(),
                 TaskID = s.TaskID.ToString(),
                 Status = s.Status,
                 LastChangeTime = s.LastChangeTime,
                 Auditor = new Auditor()
                 {
                     ID = s.Manager.ID.ToString(),
                     Name = s.Manager.NickName
                 },
                 Tagger = new Tagger()
                 {
                     ID = s.Tagger.ID.ToString(),
                     Name = s.Tagger.NickName,
                     Email = s.Tagger.Email
                 },
                 AuditRecords = s.AuditRecords
             });

            return new TaggedRecordDto()
            {
                Records = records,
                Total = total
            };
        }

        /// <summary>
        /// 标记者获取文献
        /// </summary>
        public async Task<ArticleDto> GetArticleByTaggerIdAsync(long taggerId)
        {
            // 用户角色检查
            var roleFlag = await this.Orm.Select<User>()
                .Where(s => s.ID == taggerId && s.Role == TagRoleEnum.Tagger)
                .AnyAsync();
            if (!roleFlag)
            {
                throw new WarnException("非标记员角色不能标记文章！");
            }

            /**
             * 先推送未审核通过的
             * 再推送未标记完成的
             * 最后推送未分配的
             */

            var unsanctioned = await Select
                .Where(s => s.UserID == taggerId && s.Status == TagArticleStatusEnum.Unsanctioned)
                .AnyAsync();

            if (unsanctioned)
            {
                var unsanction = await Select
                    .Where(s => s.UserID == taggerId && s.Status == TagArticleStatusEnum.Unsanctioned)
                    .ToOneAsync();

                var dto = new ArticleDto()
                {
                    ID = unsanction.ID.ToString(),
                    Content = unsanction.TaggedContent,
                    Tags = JsonConvert.DeserializeObject<ICollection<Tag>>(unsanction.TaggedArray ?? "")
                };
                return dto;
            }

            var tagging = await Select
                .Where(s => s.UserID == taggerId && s.Status == TagArticleStatusEnum.Tagging)
                .AnyAsync();
            if (tagging)
            {
                var taggingArticle = await Select
                .Where(s => s.UserID == taggerId && s.Status == TagArticleStatusEnum.Tagging)
                .ToOneAsync();

                var dto = new ArticleDto()
                {
                    ID = taggingArticle.ID.ToString(),
                    Content = taggingArticle.TaggedContent,
                    Tags = JsonConvert.DeserializeObject<ICollection<Tag>>(taggingArticle.TaggedArray ?? "")
                };
                return dto;
            }

            var untagged = await Select
                .Where(s => s.Status == TagArticleStatusEnum.Untagged)
                .ToOneAsync();

            if (untagged != null)
            {
                untagged.Status = TagArticleStatusEnum.Tagging;
                untagged.UserID = taggerId;
                untagged.TaskID = _idGenerator.Value.CreateId();
                await UpdateAsync(untagged);

                return new ArticleDto()
                {
                    ID = untagged.ID.ToString(),
                    Content = untagged.TaggedContent,
                    Tags = JsonConvert.DeserializeObject<ICollection<Tag>>(untagged.TaggedArray ?? "")
                };
            }

            return await Task.FromResult<ArticleDto>(null);
        }

        public async Task<bool> CheckCanEditAsync(long articleId)
        {
            var article = await this.Select
                   .Where(s => s.ID == articleId)
                   .ToOneAsync();
            return !(article.Status == TagArticleStatusEnum.Unaudited
                   || article.Status == TagArticleStatusEnum.Audited);
        }

        public async Task<bool> CheckCanAuditAsync(long articleId)
        {
            var article = await this.Select
               .Where(s => s.ID == articleId)
               .ToOneAsync();
            return article.Status == TagArticleStatusEnum.Unaudited;
        }

        public async Task<bool> SaveTaggedRecordAsync(ArticleRecordRequest record)
        {
            var model = await this.Select
                .Where(s => s.ID == long.Parse(record.ID))
                .ToOneAsync();

            model.TaggedArray = JsonConvert.SerializeObject(record.Tags);
            model.TaggedContent = record.TaggedContent;
            model.LastChangeTime = DateTime.Now;

            return await this.UpdateAsync(model) > 0;
        }

        /// <summary>
        /// 提交审核
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public async Task<bool> SubmitAuditAsync(long articleId)
        {
            return await this.Where(s => s.ID == articleId)
                      .ToUpdate()
                      .Set(s => s.Status, TagArticleStatusEnum.Unaudited)
                      .Set(s => s.LastChangeTime, DateTime.Now)
                      .ExecuteAffrowsAsync() > 0;
        }

        /// <summary>
        /// 标记无效文章
        /// </summary>
        public async Task<bool> SetUnavailArticleAsync(long articleId)
        {
            return await this.Where(s => s.ID == articleId)
              .ToUpdate()
              .Set(s => s.Status, TagArticleStatusEnum.Unavail)
              .Set(s => s.LastChangeTime, DateTime.Now)
              .ExecuteAffrowsAsync() > 0;
        }

        /// <summary>
        /// 审核文章
        /// </summary>
        public async Task<bool> AuditArticleAsync(AuditArticleRequest article)
        {
            using (var unitOfWork = this.Orm.CreateUnitOfWork())
            {
                try
                {
                    var articleRecord = (await this.Where(s => s.ID == long.Parse(article.ID))
                       .ToUpdate()
                       .Set(s => s.AdminID, article.AuditorID)
                       .Set(s => s.Status, article.Status)
                       .Set(s => s.LastChangeTime, DateTime.Now)
                       .WithTransaction(unitOfWork.GetOrBeginTransaction())
                       .ExecuteUpdatedAsync())
                       .FirstOrDefault();

                    var auditRecord = new AuditRecord()
                    {
                        TaggedRecordID = articleRecord.ID,
                        CleanedArticleID = articleRecord.CleanedArticleID,
                        TaskID = articleRecord.TaskID,
                        TaggerID = articleRecord.UserID,
                        AuditorID = articleRecord.AdminID,
                        Status = article.Status,
                        Remark = article.Remark,
                        RecordTime = DateTime.Now,
                    };

                    var flag = await this.Orm.Insert<AuditRecord>(auditRecord)
                        .IgnoreColumns(s => s.ID)
                        .WithTransaction(unitOfWork.GetOrBeginTransaction())
                        .ExecuteAffrowsAsync() > 0;

                    unitOfWork.Commit();
                    return flag;
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw new ErrorException("保存标记记录时异常！", ex);
                }
            }
        }
    }
}
