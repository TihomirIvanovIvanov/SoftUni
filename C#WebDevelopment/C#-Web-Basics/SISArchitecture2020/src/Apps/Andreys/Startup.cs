using Andreys.Data;
using Andreys.Services;
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
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProductsService, ProductsService>();
        }
    }
}