using System.Data.Common;
using System.Reflection;
using Autofac;
using Entity.Entities;
using FreeSql;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Collections.Generic;
using System.Text;

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

        private static string DbCommandFormatter(DbCommand dbCommand)
        {
            var paramNames = new List<string>();
            var @params = new List<string>();
            var @sets = new List<string>();
            foreach (DbParameter param in dbCommand.Parameters)
            {
                paramNames.Add(param.ParameterName);
                @params.Add($"{param.ParameterName} {param.DbType}");
                @sets.Add($"set {param.ParameterName}={param.Value}");
            }
            @params.Add("@str nvarchar(max)");
            sets.Add($"set @str=N'{dbCommand.CommandText}'");

            var exec = $"exec sp_executesql @str,N'{string.Join(",", @params)}',{string.Join(",", paramNames)}";

            var builder = new StringBuilder();
            builder.AppendLine($"DECLARE {string.Join(",", @params)}");
            builder.AppendLine(string.Join(",", sets));
            builder.AppendLine(exec);

            return builder.ToString();
        }
    }
}
