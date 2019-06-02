﻿namespace SIS.MvcFramework
{
    using Routing;

    public interface IMvcApplication
    {
        void Configure(IServerRoutingTable serverRoutingTable);

        void ConfigureServices();
    }
}
