using System.ComponentModel;

namespace Entity.Enum
{
    /// <summary>
    /// 用户角色
    /// </summary>
    /// <remarks>Tag 模块用户类型</remarks>
    public enum TagRoleEnum
    {
        [Description("线下标记员")]
        OfflineTagger = 0,

        [Description("审核员")]
        Auditor = 1,

        [Description("线上标记员")]
        OnlineTagger = 2,
    }
}
