namespace Deepbio.Domain.Enum
{
    /// <summary>
    /// 文章审核状态
    /// </summary>
    /// <remarks>Tag 模块</remarks>
    public enum TagArticleStatusEnum
    {
        Untagged = 0,
        Tagging = 1,
        Tagged = 2,
        Unaudited = 3,
        Audited = 4,
        Unsanctioned = 5,
    }
}
