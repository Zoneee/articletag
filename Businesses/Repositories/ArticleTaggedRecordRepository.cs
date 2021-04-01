using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Businesses.Dto;
using Businesses.Interfaces;
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

            var unsanctioned = await Select
                .Where(s => s.UserID == userid && s.Status == TagArticleStatusEnum.Unsanctioned)
                .AnyAsync();

            if (unsanctioned)
            {
                var unsanction = await Select
                    .Where(s => s.UserID == userid && s.Status == TagArticleStatusEnum.Unsanctioned)
                    .ToOneAsync(s => new ArticleDto()
                    {
                        ID = s.ID,
                        Content = s.TaggedContent,
                        Tags = JsonSerializer.Deserialize<IEnumerable<Tag>>(s.TaggedArray, null)
                    });
                return unsanction;
            }

            var tagging = await Select
                .Where(s => s.UserID == userid && s.Status == TagArticleStatusEnum.Tagging)
                .AnyAsync();
            if (tagging)
            {
                var taggingArticle = await Select
                .Where(s => s.UserID == userid && s.Status == TagArticleStatusEnum.Tagging)
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

            untagged.Status = TagArticleStatusEnum.Tagging;
            await UpdateAsync(untagged);

            return new ArticleDto()
            {
                ID = untagged.ID,
                Content = untagged.TaggedContent,
                Tags = JsonSerializer.Deserialize<IEnumerable<Tag>>(untagged.TaggedArray, null)
            };
        }
    }
}
