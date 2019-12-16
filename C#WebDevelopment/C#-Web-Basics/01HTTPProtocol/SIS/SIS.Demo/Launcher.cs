namespace SIS.Demo
{
    using Controllers;
    using global::Demo.Data;
    using HTTP.Enums;
    using WebServer;
    using WebServer.Routing;
    using WebServer.Routing.Contracts;

    public class Launcher
    {
        static void Main(string[] args)
        {
            using (var context = new DemoDbContext())
            {
                context.Database.EnsureCreated();
            }

            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable
                .Add(HttpRequestMethod.Get, "/", httpRequest => new HomeController(httpRequest).Index(httpRequest));

            serverRoutingTable
                .Add(HttpRequestMethod.Get, "/user/login", httpRequest => new UsersController().Login(httpRequest));

            serverRoutingTable
                .Add(HttpRequestMethod.Get, "/user/register", httpRequest => new UsersController().Register(httpRequest));

            serverRoutingTable
                .Add(HttpRequestMethod.Get, "/user/logout", httpRequest => new UsersController().Logout(httpRequest));

            serverRoutingTable
                .Add(HttpRequestMethod.Get, "/user/logout", httpRequest => new UsersController().Logout(httpRequest));

            serverRoutingTable
                .Add(HttpRequestMethod.Get, "/home", httpRequest => new HomeController(httpRequest).Home(httpRequest));

            serverRoutingTable
                .Add(HttpRequestMethod.Post, "/user/login", httpRequest => new UsersController().LoginConfirm(httpRequest));

            serverRoutingTable
                .Add(HttpRequestMethod.Post, "/user/register", httpRequest => new UsersController().RegisterConfirm(httpRequest));

            Server server = new Server(8000, serverRoutingTable);
            server.Run();
        }
    }
}
