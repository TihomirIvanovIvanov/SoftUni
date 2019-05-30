namespace SIS.MvcFramework
{
    using WebServer.Routing;

    public interface IMvcApplication
    {
        void Configure(IServerRoutingTable serverRoutingTable);

        void ConfigureServices();
    }
}
