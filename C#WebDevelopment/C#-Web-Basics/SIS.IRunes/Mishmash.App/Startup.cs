﻿namespace Mishmash.App
{
    using Data;
    using Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.DependencyContainer;
    using SIS.MvcFramework.Routing;

    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var context = new MishmashDbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            //serviceProvider.Add<IAlbumService, AlbumService>();
            //serviceProvider.Add<ITrackService, TrackService>();
            serviceProvider.Add<IUserService, UserService>();
        }
    }
}
