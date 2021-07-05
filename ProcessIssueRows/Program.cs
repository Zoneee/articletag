using System;
using Autofac;

namespace ProcessIssueRows
{
    /// <summary>
    /// 逐行处理、更正有问题的html
    /// </summary>
    class Program
    {
        private static IContainer container { get; set; }
        static void Main(string[] args)
        {
            using var scope = container.BeginLifetimeScope();
            var startup = scope.Resolve<Startup>();
        }
    }
}
