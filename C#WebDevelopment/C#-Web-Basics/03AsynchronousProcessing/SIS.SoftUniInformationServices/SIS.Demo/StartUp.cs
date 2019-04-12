namespace SIS.Demo
{
    using Http.Enum;
    using WebServer;
    using WebServer.Routing;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var serverRoutingTable = new ServerRoutingTable();
            serverRoutingTable.Routes[HttpRequestMethod.GET]["/"] = request => new HomeController().Index();
            var server = new Server(80, serverRoutingTable);

            server.Run();
        }
    }
}
