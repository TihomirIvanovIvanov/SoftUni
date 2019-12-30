using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SIS.MvcFramework.DependencyContainer
{
    public class ServiceProvider : IServiceProvider
    {
        private readonly IDictionary<Type, Type> dependencyContainer = new ConcurrentDictionary<Type, Type>();

        public void Add<TSourse, TDestination>() 
            where TDestination : TSourse
        {
            this.dependencyContainer[typeof(TSourse)] = typeof(TDestination);
        }

        public object CreateInstance(Type type)
        {
            if (this.dependencyContainer.ContainsKey(type))
            {
                type = this.dependencyContainer[type];
            }

            var contstructor = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                .OrderBy(x => x.GetParameters().Count())
                .FirstOrDefault();

            if (contstructor == null)
            {
                return null;
            }

            var parameters = contstructor.GetParameters();
            var parameterInstances = new List<object>();

            foreach (var parameter in parameters)
            {
                var parameterInstance = CreateInstance(parameter.ParameterType);
                parameterInstances.Add(parameterInstance);
            }

            var obj = contstructor.Invoke(parameterInstances.ToArray());
            return obj;
        }
    }
}
