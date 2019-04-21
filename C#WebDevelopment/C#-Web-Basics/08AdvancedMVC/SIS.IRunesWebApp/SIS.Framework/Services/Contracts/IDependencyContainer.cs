namespace SIS.Framework.Services.Contracts
{
    using System;

    public interface IDependencyContainer
    {
        void RegestryDependency<TSourse, TDestination>();

        T CreateInstance<T>();

        object CreateInstance(Type type);
    }
}
