﻿using SIS.MvcFramework;
using SIS.MvcFramework.DependencyContainer;
using SIS.MvcFramework.Routing;

namespace Musaca.Web
{
    internal class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            //using var context = new MusacaDbContext();
            //context.Database.EnsureCreate();
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
        }
    }
}