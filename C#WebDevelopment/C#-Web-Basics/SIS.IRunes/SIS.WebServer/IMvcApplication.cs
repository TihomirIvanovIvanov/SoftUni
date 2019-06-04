namespace SIS.MvcFramework
{
    using Routing;
    using SIS.MvcFramework.DependencyContainer;

    public interface IMvcApplication
    {
        void Configure(IServerRoutingTable serverRoutingTable);

        void ConfigureServices(IServiceProvider serviceProvider);
    }
}
