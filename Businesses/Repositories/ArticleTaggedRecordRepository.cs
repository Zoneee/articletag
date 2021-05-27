using System;
using System.Collections.Generic;
using System.Linq;
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
                Tags = JsonConvert.DeserializeObject<ICollection<Tag>>(article.TaggedArray ?? ""),
                Review = article.Review
            };

            return dto;
        }

        public async Task<TaggedRecordDto> GetArticlesByPagingAsync(
            long userid,
            int page, int size,
            TagArticleStatusEnum? status,
            bool? review,
            string taggerNickName)
        {
            var user = await Orm.GetRepository<User>()
                .Select
                .Where(s => s.ID == userid)
                .ToOneAsync();

            var records = await this.Select
             .WhereIf(user.Role != TagRoleEnum.Auditor, s => s.UserID == userid)
             .WhereIf(status != null, s => s.Status == status)
             .WhereIf(review != null, s => s.Review == review)
             .WhereIf(!string.IsNullOrWhiteSpace(taggerNickName), s => s.Tagger.NickName.Contains(taggerNickName))
             .Page(page, size)
             .Include(s => s.Tagger)
             .Include(s => s.Manager)
             .IncludeMany(s => s.AuditRecords)
             .Count(out var total)
             .OrderBy(s => s.ID)
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
                 Tagger = new TaggerDto()
                 {
                     ID = s.Tagger.ID.ToString(),
                     Name = s.Tagger.NickName,
                     Email = s.Tagger.Email
                 },
                 AuditRecords = s.AuditRecords,
                 Review = s.Review
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
                .Where(s => s.ID == taggerId
                    && (s.Role == TagRoleEnum.OfflineTagger || s.Role == TagRoleEnum.OnlineTagger))
                .AnyAsync();
            if (!roleFlag)
            {
                throw new WarnException("非标记员角色不能标记文章！");
            }

            // 获取用户
            var tagger = await this.Orm.Select<User>()
                .Where(s => s.ID == taggerId)
                .ToOneAsync();

            /**
             * 先推送未审核通过的
             * 再推送未标记完成的
             * 如果是 线下标记员 优先推送预处理的文章，如果是 线上标记员 优先推送未处理的文章
             * 最后推送未分配的
             */

            // 未通过审核的
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
                    Tags = JsonConvert.DeserializeObject<ICollection<Tag>>(unsanction.TaggedArray ?? ""),
                    Review = unsanction.Review
                };
                return dto;
            }

            // 标记中的
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
                    Tags = JsonConvert.DeserializeObject<ICollection<Tag>>(taggingArticle.TaggedArray ?? ""),
                    Review = taggingArticle.Review
                };
                return dto;
            }

            // 未标记的
            ArticleTaggedRecord untagged = null;
            switch (tagger.Role)
            {
                case TagRoleEnum.OfflineTagger:
                    {
                        untagged = await Select
                            .Where(s => s.Status == TagArticleStatusEnum.PreProcessed)
                            .ToOneAsync()
                            ?? await Select
                              .Where(s => s.Status == TagArticleStatusEnum.Untagged)
                              .ToOneAsync();
                    }
                    break;

                case TagRoleEnum.Auditor:
                case TagRoleEnum.OnlineTagger:
                    {
                        untagged = await Select
                          .Where(s => s.Status == TagArticleStatusEnum.Untagged)
                          .ToOneAsync()
                          ?? await Select
                            .Where(s => s.Status == TagArticleStatusEnum.PreProcessed)
                            .ToOneAsync();
                    }
                    break;
            }

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
                    Tags = JsonConvert.DeserializeObject<ICollection<Tag>>(untagged.TaggedArray ?? ""),
                    Review = untagged.Review
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
            return article.Status == TagArticleStatusEnum.Unaudited
                || article.Status == TagArticleStatusEnum.Unavail;
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

        public async Task<bool> SetReviewArticleAsync(long articleId, bool review)
        {
            return await this.UpdateDiy
                      .Where(s => s.ID == articleId)
                      .Set(s => s.Review, review)
                      .ExecuteAffrowsAsync() > 0;
        }

        public async Task<ArticleDto> GetCanAuditArticleAsync(long taggerId)
        {
            var article = await Select
                .Where(s => s.Status == TagArticleStatusEnum.Unaudited || s.Status == TagArticleStatusEnum.Unavail)
                .Where(s => s.UserID == taggerId)
                .ToOneAsync();

            if (article == null)
            {
                throw new Exception("未查询到可审核的文章！");
            }

            var dto = new ArticleDto()
            {
                ID = article.ID.ToString(),
                Content = article.TaggedContent,
                Tags = JsonConvert.DeserializeObject<ICollection<Tag>>(article.TaggedArray ?? ""),
                Review = article.Review
            };

            return dto;
        }

        public async Task<WorkloadDto> GetWorkloadAsync(
            DateTime? startDate,
            DateTime? endDate,
            int page, int size)
        {
            var whereSql =
                startDate != null && endDate != null
                ? "WHERE LastChangeTime BETWEEN @startDate AND @endDate"
                : string.Empty;

            var workloads = await Orm.Ado.QueryAsync<WorkloadItem>($@"
                SELECT
	                a.id,
	                a.email,
	                a.nickname,
	                tb.Untagged,
	                tb.Tagging,
	                tb.Tagged,
	                tb.Unaudited,
	                tb.Audited,
	                tb.Unsanctioned,
	                tb.Unavail,
	                tb.PreProcessed
                FROM
	                [User] AS a
	                INNER JOIN (
	                SELECT
		                tb.UserID,
		                SUM ( [0] ) AS Untagged,
		                SUM ( [1] ) AS Tagging,
		                SUM ( [2] ) AS Tagged,
		                SUM ( [3] ) AS Unaudited,
		                SUM ( [4] ) AS Audited,
		                SUM ( [5] ) AS Unsanctioned,
		                SUM ( [6] ) AS Unavail,
		                SUM ( [7] ) AS PreProcessed
	                FROM
	                    ( SELECT UserID, Status, ID, LastChangeTime FROM ArticleTaggedRecord {whereSql}) tb
                    PIVOT (COUNT ( ID ) FOR Status IN ( [0], [1], [2], [3], [4], [5], [6], [7] )) AS tb
                    GROUP BY
	                tb.UserID
	                ) tb ON a.id= tb.userid
                	ORDER BY a.id
                    OFFSET @skip ROW FETCH NEXT @size ROW ONLY
                "
             , new
             {
                 startDate,
                 endDate,
                 skip = (page - 1) * size,
                 size
             });

            var total = await Select
                  .WhereIf(startDate != null && endDate != null, r => r.LastChangeTime.Between(startDate.Value, endDate.Value))
                  .CountAsync();

            return new WorkloadDto()
            {
                Collection = workloads,
                Total = total.ToString()
            };
        }

        public async Task<TaggerDto> GetTaggerByArticleTaggedRecordIdAsync(long recordId)
        {
            var tagger = await Orm.Select<ArticleTaggedRecord, User>()
                .InnerJoin<User>((r, u) => u.ID == r.UserID)
                .Where((r, u) => r.ID == recordId)
                .ToOneAsync((r, u) => new TaggerDto()
                {
                    ID = u.ID.ToString(),
                    Email = u.Email,
                    Name = u.NickName
                });

            return tagger;
        }
    }
}
