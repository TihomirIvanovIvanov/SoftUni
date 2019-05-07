namespace SoftUniDIFramework.Injectors
{
    using Attributes;
    using Modules.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Injector
    {
        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            var hasConstructorAttribute = this.CheckForConstructorInjection<TClass>();
            var hasFieldAttribute = this.CheckForFieldInjection<TClass>();

            if (hasConstructorAttribute && hasFieldAttribute)
            {
                throw new ArgumentException("There must be only field or constructor annotated with Inject attribute");
            }

            if (hasConstructorAttribute)
            {
                return this.CreateConstructorInjection<TClass>();
            }
            else if (hasFieldAttribute)
            {
                return this.CreateFieldsInjection<TClass>();
            }

            return default(TClass);
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields((BindingFlags)62)
                .Any(f => f.GetCustomAttributes<Inject>(true).Any());
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass)
                .GetConstructors()
                .Any(c => c.GetCustomAttributes<Inject>().Any());
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            var classType = typeof(TClass);
            if (classType == null)
            {
                return default(TClass);
            }

            var constructors = classType.GetConstructors();
            foreach (var constructor in constructors)
            {
                if (!CheckForConstructorInjection<TClass>())
                {
                    continue;
                }

                var inject = (Inject)constructor
                    .GetCustomAttributes<Inject>(true)
                    .FirstOrDefault();

                var paramType = constructor.GetParameters();

                var constructorParam = new object[paramType.Length];

                var i = 0;

                foreach (var parameterInfo in paramType)
                {
                    var named = parameterInfo.GetCustomAttribute<Named>();
                    Type dependency = null;

                    if (named == null)
                    {
                        dependency = this.module.GetMapping(parameterInfo.ParameterType, inject);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(parameterInfo.ParameterType, named);
                    }

                    if (parameterInfo.ParameterType.IsAssignableFrom(dependency))
                    {
                        var instance = this.module.GetInstance(dependency);

                        if (instance != null)
                        {
                            constructorParam[i++] = instance;
                        }
                        else
                        {
                            instance = Activator.CreateInstance(dependency);
                            constructorParam[i++] = instance;
                            this.module.SetInstance(parameterInfo.ParameterType, instance);
                        }
                    }
                }

                return (TClass)Activator.CreateInstance(classType, constructorParam);
            }

            return default(TClass);
        }

        private TClass CreateFieldsInjection<TClass>()
        {
            var classType = typeof(TClass);
            var classInstance = this.module.GetInstance(classType);

            if (classInstance == null)
            {
                classInstance = Activator.CreateInstance(classType);
                this.module.SetInstance(classType, classInstance);
            }

            var fields = classType.GetFields((BindingFlags)62);

            foreach (var field in fields)
            {
                if (field.GetCustomAttributes<Inject>(true).Any())
                {
                    var injection = (Inject)field
                        .GetCustomAttributes<Inject>(true)
                        .FirstOrDefault();

                    Type dependency = null;

                    var named = field.GetCustomAttributes<Named>(true);
                    var type = field.FieldType;

                    if (named == null)
                    {
                        dependency = this.module.GetMapping(type, injection);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(type, named);
                    }

                    if (type.IsAssignableFrom(dependency))
                    {
                        var instance = this.module.GetInstance(dependency);
                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            this.module.SetInstance(dependency, instance);
                        }

                        field.SetValue(classInstance, instance);
                    }
                }
            }

            return (TClass)classInstance;
        }
    }
}
