using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;
using System.Text;
using Autofac;

namespace Entity
{
    public static class DependencyInjection
    {
        public static ContainerBuilder AddEntity(this ContainerBuilder builder)
        {
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
