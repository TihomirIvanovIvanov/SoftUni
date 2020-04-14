﻿using Andreys.Data;
using SIS.HTTP;
using SIS.MvcFramework;
using System.Collections.Generic;

namespace Andreys
{
    internal class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            using var dbContext = new ApplicationDbContext();
            dbContext.Database.EnsureCreated();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
        }
    }
}