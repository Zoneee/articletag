using Autofac;
using Businesses.Interfaces;
using Businesses.Repositories;
using FreeSql;
using IdGen;
using Microsoft.Extensions.Configuration;

namespace Businesses
{
    public static class DependencyInjection
    {
        public static ContainerBuilder AddBusiness(this ContainerBuilder builder)
        {
            // 注册FreeSql
            builder.Register(c =>
            {
                var configuration = c.Resolve<IConfiguration>();
                var connection = configuration.GetConnectionString("MSSQL");
                IFreeSql FreeSql = new FreeSqlBuilder()
                             .UseConnectionString(DataType.SqlServer, connection)
#if DEBUG
                             .UseMonitorCommand(dbcommand =>
                             {
                                 System.Console.WriteLine(dbcommand.CommandText);
                             })
#endif
                             .Build(); //请务必定义成 Singleton 单例模式
                return FreeSql;
            }).SingleInstance();

            // 注册Business
            builder.RegisterType(typeof(ArticleTaggedRecordRepository)).As(typeof(IArticleTaggedRecordRepository));
            builder.RegisterType(typeof(UserRepository)).As(typeof(IUserRepository));

            builder.RegisterType<IdGenerator>().As<IIdGenerator<long>>().SingleInstance();

            return builder;
        }
    }
}
