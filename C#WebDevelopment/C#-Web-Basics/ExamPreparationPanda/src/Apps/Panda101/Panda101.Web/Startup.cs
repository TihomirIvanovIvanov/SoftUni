using Panda101.Data;
using SIS.MvcFramework;
using SIS.MvcFramework.DependencyContainer;
using SIS.MvcFramework.Routing;

namespace Panda101.Web
{
    internal class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using var context = new Panda101DbContext();
            context.Database.EnsureCreated();
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            throw new System.NotImplementedException();
        }
    }
}