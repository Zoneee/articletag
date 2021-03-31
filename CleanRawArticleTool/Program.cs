using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using ILogger = NLog.ILogger;

namespace CleanRawArticleTool
{
    class Program
    {
        private static ILogger log = LogManager.GetCurrentClassLogger();

       
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);


            var c = new Cleaner();
            c.DoClean();

        }

        private static void ConfigureServices(ServiceCollection services)
        {

            services.AddLogging(builder =>
            {
                builder.AddNLog("nlog.config");
            });

        }
        
    }
}
