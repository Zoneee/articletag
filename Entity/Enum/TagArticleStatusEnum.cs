using System.ComponentModel;

namespace Entity.Enum
{
    /// <summary>
    /// 文章状态
    /// </summary>
    /// <remarks>Tag 模块</remarks>
    public enum TagArticleStatusEnum
    {
        [Description("未标记")]
        Untagged = 0,

        [Description("标记中")]
        Tagging = 1,

        [Description("已标记")]
        Tagged = 2,

        [Description("未审核")]
        Unaudited = 3,

        [Description("审核通过")]
        Audited = 4,

        [Description("审核不通过")]
        Unsanctioned = 5,

        [Description("无效的")]
        Unavail = 6,
    }
}
