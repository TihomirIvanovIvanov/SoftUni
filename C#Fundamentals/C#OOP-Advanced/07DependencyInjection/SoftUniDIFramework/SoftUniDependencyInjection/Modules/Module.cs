namespace SoftUniDependencyInjection.Modules
{
    using Models;
    using Models.Contracts;
    using SoftUniDIFramework.Modules;

    public class Module : AbstractModule
    {
        public override void Configure()
        {
            this.CreateMapping<IReader, ConsoleReader>();
            this.CreateMapping<IWriter, ConsoleWriter>();
            this.CreateMapping<IWriter, FileWriter>();
        }
    }
}
