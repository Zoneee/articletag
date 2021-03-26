using Autofac;
using FreeSql;
using Microsoft.Extensions.Configuration;

namespace Entity
{
    public static class DependencyInjection
    {
        public static ContainerBuilder AddEntity(this ContainerBuilder builder)
        {
            //注册Free
            builder.Register(c =>
            {
                var configuration = c.Resolve<IConfiguration>();
                var connection = configuration.GetConnectionString("ArticleTag");
                IFreeSql FreeSql = new FreeSql.FreeSqlBuilder()
                             .UseConnectionString(DataType.SqlServer, connection)
                             .Build(); //请务必定义成 Singleton 单例模式

                return FreeSql;
            }).SingleInstance();

            return builder;
        }
    }
}
