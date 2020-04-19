using SIS.HTTP;
using SIS.MvcFramework;
using Suls.Data;
using Suls.Services;
using System.Collections.Generic;

namespace Suls
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
            serviceCollection.Add<IProblemsService, ProblemsService>();
        }
    }
}