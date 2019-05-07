namespace SoftUniDIFramework.Modules
{
    using Attributes;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class AbstractModule : IModule
    {
        private readonly IDictionary<Type, Dictionary<string, Type>> implementations;
        private readonly IDictionary<Type, object> instances;

        protected AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        //TODO maybe protected
        protected void CreateMapping<TInterface, TImplementation>()
        {
            if (!this.implementations.ContainsKey(typeof(TInterface)))
            {
                this.implementations[typeof(TInterface)] = new Dictionary<string, Type>();
            }

            this.implementations[typeof(TInterface)].Add(typeof(TImplementation).Name, typeof(TImplementation));
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            var currentImplementation = this.implementations[currentInterface];

            Type type = null;

            if (attribute is Inject)
            {
                if (currentImplementation.Count == 0)
                {
                    throw new AggregateException($"No available mapping for class: {currentInterface.FullName}");
                }
                type = currentImplementation.Values.First();
            }
            else if (attribute is Named named)
            {
                var dependencyName = named.Name;
                type = currentImplementation[dependencyName];
            }

            return type;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!this.instances.ContainsKey(implementation))
            {
                this.instances.Add(implementation, instance);
            }
        }

        public object GetInstance(Type implementation)
        {
            this.instances.TryGetValue(implementation, out object value);
            return value;
        }
    }
}
