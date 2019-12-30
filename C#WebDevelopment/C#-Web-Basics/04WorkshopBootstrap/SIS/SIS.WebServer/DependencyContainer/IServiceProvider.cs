using System;

namespace SIS.MvcFramework.DependencyContainer
{
    public interface IServiceProvider
    {
        void Add<TSourse, TDestination>()
            where TDestination : TSourse;

        object CreateInstance(Type type);
    }
}
