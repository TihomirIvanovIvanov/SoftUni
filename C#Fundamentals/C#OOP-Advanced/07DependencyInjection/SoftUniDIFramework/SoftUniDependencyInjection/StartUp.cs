namespace SoftUniDependencyInjection
{
    using Core;
    using Core.Contracts;
    //using Microsoft.Extensions.DependencyInjection;
    using Models;
    using Models.Contracts;
    using System;
    using SoftUniDIFramework;
    using SoftUniDependencyInjection.Modules;

    public class StartUp
    {
        public static void Main()
        {
            var injector = DependencyInjector.CreateInjector(new Module());

            var engine = injector.Inject<Engine>();

            engine.Run();

            //IServiceProvider serviceProvider = ConfigureServices();

            //IReader reader = new ConsoleReader();
            //IWriter writer = new FileWriter();

            //IEngine engine = new Engine(writer, reader);
            //engine.Run();
        }

        //private static IServiceProvider ConfigureServices()
        //{
        //    IServiceCollection services = new ServiceCollection();

        //    services.AddTransient<IEngine, Engine>();
        //    services.AddTransient<IReader, ConsoleReader>();
        //    services.AddTransient<IWriter, ConsoleWriter>();
        //    services.AddTransient<IWriter, FileWriter>();

        //    var service = services.BuildServiceProvider();
        //    return service;
        //}
    }
}
