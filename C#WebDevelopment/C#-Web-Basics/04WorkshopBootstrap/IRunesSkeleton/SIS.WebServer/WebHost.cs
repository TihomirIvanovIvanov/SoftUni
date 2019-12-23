using SIS.HTTP.Enums;
using SIS.HTTP.Responses;
using SIS.WebServer.Attributes;
using SIS.WebServer.Routing;
using System;
using System.Linq;
using System.Reflection;

namespace SIS.WebServer
{
    public static class WebHost
    {
        public static void Start(IMvcApplication application)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            AutoRegisterRoutes(application, serverRoutingTable);
            application.ConfigureServices();
            application.Configure(serverRoutingTable);

            var server = new Server(8000, serverRoutingTable);
            server.Run();
        }

        private static void AutoRegisterRoutes(IMvcApplication application, IServerRoutingTable serverRoutingTable)
        {
        }
    }
}
