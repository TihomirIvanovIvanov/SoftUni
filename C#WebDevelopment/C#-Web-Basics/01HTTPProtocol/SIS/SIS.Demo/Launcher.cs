namespace SIS.Demo
{
    using Controllers;
    using HTTP.Enums;
    using WebServer;
    using WebServer.Routing;
    using WebServer.Routing.Contracts;

    public class Launcher
    {
        static void Main(string[] args)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Add(HttpRequestMethod.Get, 
                "/", httpRequest
                => new HomeController().Home(httpRequest));

            Server server = new Server(8000, serverRoutingTable);
            server.Run();
        }
    }
}
