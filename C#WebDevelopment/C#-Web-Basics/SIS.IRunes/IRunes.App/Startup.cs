namespace IRunes.App
{
    using Controllers;
    using Data;
    using SIS.HTTP.Common;
    using SIS.HTTP.Enums;
    using SIS.MvcFramework;
    using SIS.WebServer;
    using SIS.WebServer.Result;
    using SIS.WebServer.Routing;
    using System;
    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var context = new RunesDbContext())
            {
                context.Database.EnsureCreated();
            }

            #region Home Routes
            serverRoutingTable.Add(HttpRequestMethod.Get, GlobalConstants.HomeRedirectPath, request =>
            new RedirectResult(GlobalConstants.HomeIndexPath));

            serverRoutingTable.Add(HttpRequestMethod.Get, GlobalConstants.HomeIndexPath, request =>
            new HomeController().Index(request));
            #endregion

            #region Users Routes
            serverRoutingTable.Add(HttpRequestMethod.Get, GlobalConstants.UsersLoginPath, request =>
            new UsersController().Login(request));

            serverRoutingTable.Add(HttpRequestMethod.Post, GlobalConstants.UsersLoginPath, request =>
            new UsersController().LoginConfirm(request));

            serverRoutingTable.Add(HttpRequestMethod.Get, GlobalConstants.UsersRegisterPath, request =>
            new UsersController().Register(request));

            serverRoutingTable.Add(HttpRequestMethod.Post, GlobalConstants.UsersRegisterPath, request =>
            new UsersController().RegisterConfirm(request));

            serverRoutingTable.Add(HttpRequestMethod.Get, GlobalConstants.UsersLogoutPath, request =>
            new UsersController().Logout(request));
            #endregion

            #region Albums Routes
            serverRoutingTable.Add(HttpRequestMethod.Get, GlobalConstants.AlbumsAllPath, request =>
            new AlbumsController().All(request));

            serverRoutingTable.Add(HttpRequestMethod.Get, GlobalConstants.AlbumsCreatePath, request =>
            new AlbumsController().Create(request));

            serverRoutingTable.Add(HttpRequestMethod.Post, GlobalConstants.AlbumsCreatePath, request =>
            new AlbumsController().CreateConfirm(request));

            serverRoutingTable.Add(HttpRequestMethod.Get, GlobalConstants.AlbumsDetailsPath, request =>
            new AlbumsController().Details(request));
            #endregion

            #region Tracks Routes
            serverRoutingTable.Add(HttpRequestMethod.Get, GlobalConstants.TracksCreatePath, request =>
            new TracksController().Create(request));

            serverRoutingTable.Add(HttpRequestMethod.Post, GlobalConstants.TracksCreatePath, request =>
            new TracksController().CreateConfirm(request));

            serverRoutingTable.Add(HttpRequestMethod.Get, GlobalConstants.TracksDetailsPath, request =>
            new TracksController().Details(request));
            #endregion
        }

        public void ConfigureServices()
        {
            throw new NotImplementedException();
        }
    }
}