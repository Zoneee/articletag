using Autofac;
using Businesses.Interfaces;
using Businesses.Repositories;

namespace Businesses
{
    public static class DependencyInjection
    {
        public static ContainerBuilder AddBusiness(this ContainerBuilder builder)
        {
            // 注册Business
            builder.RegisterType(typeof(ArticleTaggedRecordRepository)).As(typeof(IArticleTaggedRecordRepository));

            return builder;
        }
    }
}
