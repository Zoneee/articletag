using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Businesses.Dto;
using Businesses.Interfaces;
using Businesses.ViewModels.Requsets;
using Deepbio.Domain.Enum;
using Entity.Entities;
using FreeSql;

namespace Businesses.Repositories
{
    /// <summary>
    /// 文献标记记录表
    /// </summary>
    public class ArticleTaggedRecordRepository
        : BaseRepository<ArticleTaggedRecord, long>,
        IArticleTaggedRecordRepository
    {
        public ArticleTaggedRecordRepository(IFreeSql freeSql) : base(freeSql, null)
        {
        }

        public async Task<ArticleDto> GetArticleAsync(long id)
        {
            var dto = await this.Select
                   .Where(s => s.ID == id)
                   .ToOneAsync(s => new ArticleDto()
                   {
                       ID = s.ID,
                       Content = s.TaggedContent,
                       Tags = JsonSerializer.Deserialize<IEnumerable<Tag>>(s.TaggedArray, null)
                   });

            return dto;
        }

        public async Task<IEnumerable<TaggedRecordDto>> GetArticlesByPagingAsync(int page, int size)
        {
            var articles = await this.Select
                .Page(page, size)
                .Include(s => s.Tagger)
                .Include(s => s.Manager)
                .Count(out var count)
                .ToListAsync(s => new TaggedRecordDto()
                {
                    ID = s.ID,
                    CleanedArticleID = s.CleanedArticleID,
                    TaskID = s.TaskID,
                    Status = s.Status,
                    LastChangeTime = s.LastChangeTime,
                    Manager = new Manager()
                    {
                        ID = s.Manager.ID,
                        Name = s.Manager.NickName
                    },
                    Tagger = new Tagger()
                    {
                        ID = s.Tagger.ID,
                        Name = s.Tagger.NickName,
                        Email = s.Tagger.Email
                    }
                });
            return articles;
        }

        /// <summary>
        /// 标记者获取文献
        /// </summary>
        public async Task<ArticleDto> GetArticleByTaggerIdAsync(long taggerId)
        {
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
                    .ToOneAsync(s => new ArticleDto()
                    {
                        ID = s.ID,
                        Content = s.TaggedContent,
                        Tags = JsonSerializer.Deserialize<IEnumerable<Tag>>(s.TaggedArray, null)
                    });
                return unsanction;
            }

            var tagging = await Select
                .Where(s => s.UserID == taggerId && s.Status == TagArticleStatusEnum.Tagging)
                .AnyAsync();
            if (tagging)
            {
                var taggingArticle = await Select
                .Where(s => s.UserID == taggerId && s.Status == TagArticleStatusEnum.Tagging)
                .ToOneAsync(s => new ArticleDto()
                {
                    ID = s.ID,
                    Content = s.TaggedContent,
                    Tags = JsonSerializer.Deserialize<IEnumerable<Tag>>(s.TaggedArray, null)
                });
                return taggingArticle;
            }

            var untagged = await Select
                .Where(s => s.Status == TagArticleStatusEnum.Untagged)
                .ToOneAsync();

            if (untagged != null)
            {
                untagged.Status = TagArticleStatusEnum.Tagging;
                await UpdateAsync(untagged);

                return new ArticleDto()
                {
                    ID = untagged.ID,
                    Content = untagged.TaggedContent,
                    Tags = JsonSerializer.Deserialize<IEnumerable<Tag>>(untagged.TaggedArray, null)
                };
            }

            return await Task.FromResult<ArticleDto>(null);
        }

        public async Task<bool> CheckCanEditAsync(long articleId)
        {
            return await this.Select
                   .Where(s => s.ID == articleId)
                   .ToOneAsync(s => s.Status == TagArticleStatusEnum.Unaudited
                   || s.Status == TagArticleStatusEnum.Audited);
        }

        public async Task<bool> SaveTaggedRecordAsync(ArticleRecordRequest record)
        {
            var model = await this.Select
                .Where(s => s.ID == record.ID)
                .ToOneAsync();

            model.TaggedArray = JsonSerializer.Serialize(record.Tags);
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
        /// 审核文章
        /// </summary>
        public async Task<bool> AuditArticleAsync(AuditArticleRequest article)
        {
            return await this.Where(s => s.ID == article.ID)
               .ToUpdate()
               .Set(s => s.AdminID, article.AuditorID)
               .Set(s => s.Status, article.Status)
               .Set(s => s.LastChangeTime, DateTime.Now)
               .ExecuteAffrowsAsync() > 0;
        }
    }
}
