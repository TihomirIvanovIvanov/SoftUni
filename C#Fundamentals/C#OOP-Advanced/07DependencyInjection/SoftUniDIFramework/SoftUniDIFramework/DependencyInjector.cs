namespace SoftUniDIFramework
{
    using Injectors;
    using Modules.Contracts;

    public class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
