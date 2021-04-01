using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Businesses.Dto;
using Businesses.Interfaces;
using Deepbio.Domain.Enum;
using Entity.Entities;
using FreeSql;

namespace Businesses.Commands
{
    public class ArticleBusiness : IArticleBusiness
    {
        private readonly IBaseRepository<ArticleTaggedRecord, long> _taggedRecordRepo;

        public ArticleBusiness(IBaseRepository<ArticleTaggedRecord, long> taggedRecordRepo)
        {
            _taggedRecordRepo = taggedRecordRepo;
        }

        /// <summary>
        /// 获取一篇文献
        /// </summary>
        public async Task<ArticleDto> GetArticleAsync(long userid)
        {
            /**
             * 先推送未审核通过的
             * 再推送未标记完成的
             * 最后推送未分配的
             */

            var unsanctioned = await _taggedRecordRepo.Select
                .Where(s => s.UserID == userid && s.Status == TagArticleStatusEnum.Unsanctioned)
                .AnyAsync();

            if (unsanctioned)
            {
                var unsanction = await _taggedRecordRepo.Select
                    .Where(s => s.UserID == userid && s.Status == TagArticleStatusEnum.Unsanctioned)
                    .ToOneAsync(s => new ArticleDto()
                    {
                        ID = s.ID,
                        Content = s.TaggedContent,
                        Tags = JsonSerializer.Deserialize<IEnumerable<Tag>>(s.TaggedArray, null)
                    });
                return unsanction;
            }

            var tagging = await _taggedRecordRepo.Select
                .Where(s => s.UserID == userid && s.Status == TagArticleStatusEnum.Tagging)
                .AnyAsync();
            if (tagging)
            {
                var taggingArticle = await _taggedRecordRepo.Select
                .Where(s => s.UserID == userid && s.Status == TagArticleStatusEnum.Tagging)
                .ToOneAsync(s => new ArticleDto()
                {
                    ID = s.ID,
                    Content = s.TaggedContent,
                    Tags = JsonSerializer.Deserialize<IEnumerable<Tag>>(s.TaggedArray, null)
                });
                return taggingArticle;
            }

            var untagged = await _taggedRecordRepo.Select
                .Where(s => s.UserID == userid && s.Status == TagArticleStatusEnum.Untagged)
                .ToOneAsync();

            untagged.Status = TagArticleStatusEnum.Tagging;
            await _taggedRecordRepo.UpdateAsync(untagged);

            return new ArticleDto()
            {
                ID = untagged.ID,
                Content = untagged.TaggedContent,
                Tags = JsonSerializer.Deserialize<IEnumerable<Tag>>(untagged.TaggedArray, null)
            };
        }
    }
}
