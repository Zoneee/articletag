using System.Reflection;
using Autofac;
using Entity.Entities;
using FreeSql;
using Microsoft.Extensions.Configuration;

namespace Entity
{
    public static class DependencyInjection
    {
        public static ContainerBuilder AddEntity(this ContainerBuilder builder)
        {
            builder.Register<IFreeSql>(c =>
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

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            return builder;
        }
    }
}
