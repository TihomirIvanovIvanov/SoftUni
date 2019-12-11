namespace SIS.Demo
{
    using Controllers;
    using HTTP.Enums;
    using WebServer;
    using WebServer.Routing;

    public class Launcher
    {
        static void Main(string[] args)
        {
            var serverRountingTable = new ServerRoutingTable();

            serverRountingTable.Add(
                HttpRequestMethod.Get, 
                "/", 
                httpRequest => new HomeController().Home(httpRequest));

            var server = new Server(8000, serverRountingTable);
            server.Run();
        }
    }
}
