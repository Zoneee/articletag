using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FreeSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProcessIssueRows
{
    public class Startup
    {
        private IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigServices(IServiceCollection services)
        {
           
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var configuration = c.Resolve<IConfiguration>();
                var connection = configuration.GetConnectionString("MYSQL");
                IFreeSql FreeSql = new FreeSqlBuilder()
                    .UseAutoSyncStructure(true)
                    .UseConnectionString(DataType.SqlServer, connection)
                    .Build(); 
                return FreeSql;
            }).SingleInstance();
        }
    }


}
