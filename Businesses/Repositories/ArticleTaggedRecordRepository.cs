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
            var record = await Orm.Select<ArticleTaggedRecord, AuditRecord>()
                     .Where((article, audit) => article.ID == id)
                     .LeftJoin((article, audit) => article.ID == audit.TaggedRecordID)
                     .OrderByDescending((article, audit) => audit.RecordTime)
                     .ToOneAsync((article, audit) => new
                     {
                         ID = article.ID,
                         TaggedContent = article.TaggedContent,
                         TaggedArray = article.TaggedArray,
                         Review = article.Review,
                         Status = article.Status,
                         LastRemark = audit.Remark,
                         article.LastChangeTime
                     });

            var dto = new ArticleDto()
            {
                ID = record.ID.ToString(),
                Content = record.TaggedContent,
                Tags = JsonConvert.DeserializeObject<ICollection<Tag>>(record.TaggedArray ?? ""),
                Review = record.Review,
                Status = record.Status,
                LastRemark = record.LastRemark,
                LastChangeTime = record.LastChangeTime
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
             * 先派发“未通过审核的”
             * 在派发“标记中的”
             * 最后根据用户类型选择派发“预处理的”或“未标记的”
             */

            var statusOrder = new TagArticleStatusEnum[]
            {
                TagArticleStatusEnum.Unsanctioned, // 未通过审核的
                TagArticleStatusEnum.Tagging, // 标记中的
            };

            foreach (var status in statusOrder)
            {
                var flag = await Select
                    .Where(s => s.UserID == taggerId && s.Status == status)
                    .AnyAsync();
                if (flag)
                {
                    var record = await Orm.Select<ArticleTaggedRecord, AuditRecord>()
                         .Where((article, audit) => article.UserID == taggerId)
                         .Where((article, audit) => article.Status == status)
                         .LeftJoin((article, audit) => article.ID == audit.TaggedRecordID)
                         .OrderByDescending((article, audit) => audit.RecordTime)
                         .ToOneAsync((article, audit) => new
                         {
                             ID = article.ID,
                             TaggedContent = article.TaggedContent,
                             TaggedArray = article.TaggedArray,
                             Review = article.Review,
                             Status = article.Status,
                             LastRemark = audit.Remark,
                             article.LastChangeTime
                         });

                    var dto = new ArticleDto()
                    {
                        ID = record.ID.ToString(),
                        Content = record.TaggedContent,
                        Tags = JsonConvert.DeserializeObject<ICollection<Tag>>(record.TaggedArray ?? ""),
                        Review = record.Review,
                        Status = record.Status,
                        LastRemark = record.LastRemark,
                        LastChangeTime = record.LastChangeTime
                    };
                    return dto;
                }
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
                    Review = untagged.Review,
                    Status = untagged.Status
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
                || article.Status == TagArticleStatusEnum.Skiped;
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
            var article = await this.Where(s => s.ID == articleId)
                .Include(s => s.Tagger)
                .ToOneAsync();
            article.Status = TagArticleStatusEnum.Skiped;
            article.LastChangeTime = DateTime.Now;

            if (article.Tagger.CanSkipTimesPerDay <= 0)
            {
                throw new WarnException($"今日可跳过文章次数限额为：{article.Tagger.CanSkipTimesPerDay}");
            }

            using (var uow = Orm.CreateUnitOfWork())
            {
                try
                {
                    this.UnitOfWork = uow;
                    var userRepos = Orm.GetRepository<User>();
                    userRepos.UnitOfWork = uow;

                    var skipFlag = await this.UpdateAsync(article) > 0;

                    if (skipFlag)
                    {
                        var subtractFlag = await userRepos
                             .Where(s => s.ID == article.Tagger.ID)
                             .ToUpdate()
                             .Set(s => s.CanSkipTimesPerDay - 1)
                             .ExecuteAffrowsAsync();
                    }
                    uow.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    throw ex;
                }
            }
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

        public async Task<ArticleDto> GetCanAuditArticleByTaggerIdAsync(long taggerId)
        {
            var article = await Select
                .Where(s => s.Status == TagArticleStatusEnum.Unaudited || s.Status == TagArticleStatusEnum.Skiped)
                .Where(s => s.UserID == taggerId)
                .Include(s => s.Tagger)
                .ToOneAsync();

            if (article == null)
            {
                throw new WarnException($"未查询到{article.Tagger.Email}可审核的文章！");
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
	                tb.Skiped,
	                tb.PreProcessed,
	                tb.Unavail
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
		                SUM ( [6] ) AS Skiped,
		                SUM ( [7] ) AS PreProcessed,
		                SUM ( [8] ) AS Unavail
	                FROM
	                    ( SELECT UserID, Status, ID, LastChangeTime FROM ArticleTaggedRecord {whereSql}) tb
                    PIVOT (COUNT ( ID ) FOR Status IN ( [0], [1], [2], [3], [4], [5], [6], [7], [8] )) AS tb
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
