namespace Employee.App
{
    using System;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;

    using Employees.Data;
    using Employees.Services;
    using AutoMapper;

    public class StartUp
    {
        static void Main()
        {
            var serviceProvider = ConfigureServices();
            var engine = new Engine(serviceProvider);
            engine.Run();
        }

        static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<EmployeeContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddTransient<EmloyeeService>();

            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<AutomapperProfile>());

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
