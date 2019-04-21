using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SIS.Framework.Services.Contracts;

namespace SIS.Framework.Services
{
    public class DependencyContainer : IDependencyContainer
    {
        private readonly IDictionary<Type, Type> dependencyMap;

        public DependencyContainer(IDictionary<Type, Type> dependencyMap)
        {
            this.dependencyMap = dependencyMap;
        }

        private Type this[Type key]
            => this.dependencyMap.ContainsKey(key) ? this.dependencyMap[key] : null;

        public void RegestryDependency<TSourse, TDestination>()
        {
            this.dependencyMap[typeof(TSourse)] = typeof(TDestination);
        }

        public T CreateInstance<T>() => (T)CreateInstance(typeof(T));

        public object CreateInstance(Type type)
        {
            var typeInstance = this[type] ?? type;

            if (typeInstance.IsInterface || typeInstance.IsAbstract)
            {
                throw new InvalidOperationException($"Type {typeInstance.FullName} cannot be instantiated. Abstract type and interfaces cannot be instantiated.");
            }

            var constructor = typeInstance
                .GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .First();

            var constructorParameters = constructor.GetParameters();

            var constructorParametersObjects = new object[constructorParameters.Length];

            for (int i = 0; i < constructorParameters.Length; i++)
            {
                constructorParametersObjects[i] = this.CreateInstance(constructorParameters[i].ParameterType);
            }

            return constructor.Invoke(constructorParametersObjects);
        }
    }
}
