using Autofac;
using Businesses.Interfaces;
using Businesses.Repositories;
using IdGen;

namespace Businesses
{
    public static class DependencyInjection
    {
        public static ContainerBuilder AddBusiness(this ContainerBuilder builder)
        {
            // 注册Business
            builder.RegisterType(typeof(ArticleTaggedRecordRepository)).As(typeof(IArticleTaggedRecordRepository));

            builder.RegisterType<IdGenerator>().As<IIdGenerator<long>>().SingleInstance();

            return builder;
        }
    }
}
