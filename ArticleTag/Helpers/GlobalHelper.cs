namespace ArticleTag.Helpers
{
    public class GlobalHelper
    {
        /// <summary>
        /// "{userid}+{userversion}"
        /// </summary>
        public const string UserCacheKeyFormatter = "{0}+{1}";

        /// <summary>
        /// 用户每日可跳过文章次数
        /// ClaimsType
        /// </summary>
        public const string ClaimsTypeUserCanSkipTimes = "CanSkipTimes";

        /// <summary>
        /// 用户版本
        /// ClaimsType
        /// （用于用户登出，使jwt失效）
        /// </summary>
        public const string ClaimsTypeUserVersion = "UserVersion";

        /// <summary>
        /// 用户每日可跳过文章次数
        /// </summary>
        public const int UserCanSkipTimesPerDay = 10;
    }
}
