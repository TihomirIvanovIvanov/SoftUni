namespace IRunes.App
{
    using SIS.WebServer;
    using SIS.WebServer.Result;
    using SIS.WebServer.Routing;
    using SIS.HTTP.Enums;
    using Data;
    using IRunes.App.Controllers;
    using SIS.HTTP.Common;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            using (var context = new RunesDbContext())
            {
                context.Database.EnsureCreated();
            }

            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            Configure(serverRoutingTable);

            Server server = new Server(8000, serverRoutingTable);
            server.Run();
        }

        private static void Configure(ServerRoutingTable serverRoutingTable)
        {
            #region Home Routes

            serverRoutingTable.Add(HttpRequestMethod.Get, GlobalConstants.HomeRedirectPath, request => 
            new RedirectResult(GlobalConstants.HomeIndexPath));

            serverRoutingTable.Add(HttpRequestMethod.Get, GlobalConstants.HomeIndexPath, request => 
            new HomeController().Index(request));

            #endregion

            #region User Routes

            serverRoutingTable.Add(HttpRequestMethod.Get, GlobalConstants.UsersLoginPath, request => 
            new UserController().Login(request));

            serverRoutingTable.Add(HttpRequestMethod.Post, GlobalConstants.UsersLoginPath, request =>
            new UserController().LoginConfirm(request));

            serverRoutingTable.Add(HttpRequestMethod.Get, GlobalConstants.UsersRegisterPath, request =>
            new UserController().Register(request));

            serverRoutingTable.Add(HttpRequestMethod.Post, GlobalConstants.UsersRegisterPath, request =>
            new UserController().RegisterConfirm(request));

            serverRoutingTable.Add(HttpRequestMethod.Get, GlobalConstants.UsersLogoutPath, request =>
            new UserController().Logout(request));

            #endregion
        }
    }
}
