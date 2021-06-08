using System;
using System.Threading;
using System.Threading.Tasks;
using ArticleTag.Helpers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ArticleTag
{
    internal class SkipTimeResetTask : BackgroundService
    {
        private readonly IFreeSql _orm;
        private readonly ILogger<SkipTimeResetTask> _logger;

        public SkipTimeResetTask(IFreeSql orm, ILogger<SkipTimeResetTask> logger)
        {
            _orm = orm;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ExecuteCoreAsync();
            }
        }

        private async Task ExecuteCoreAsync()
        {
            try
            {
                var current = DateTime.Now;
                var nextday = new DateTime(current.Year, current.Month, current.Day).AddDays(1);

                var delayTime = nextday.Subtract(current);
                _logger.LogInformation($"{delayTime.TotalSeconds}秒后执行用户每日可跳过次数重置任务");
                await Task.Delay(delayTime);

                _logger.LogInformation("开始用户每日可跳过次数重置任务");

                var affectRowNum = await _orm.GetRepository<Entity.Entities.User>()
                    .Select.ToUpdate().Set(s => s.CanSkipTimesPerDay, GlobalHelper.UserCanSkipTimesPerDay)
                    .ExecuteAffrowsAsync();
                if (affectRowNum > 0)
                {
                    _logger.LogInformation($"用户每日可跳过次数重置任务执行成功。影响行数：{affectRowNum}");
                }
                else
                {
                    _logger.LogInformation("用户每日可跳过次数重置任务执行失败");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"执行用户每日可跳过次数重置任务异常！");
            }
        }
    }
}
