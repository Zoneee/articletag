using System.Reflection;
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
    }
}
