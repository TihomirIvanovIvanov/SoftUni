using Microsoft.EntityFrameworkCore;
using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Data;
using SULS.Services;
using System.Collections.Generic;

namespace SULS.Web
{
    internal class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            using var context = new SUSLContext();
            context.Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
        }
    }
}