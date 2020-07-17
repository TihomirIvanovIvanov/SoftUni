using Employees.Data;
using Employees.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employees.App
{
    public class Program
    {
        public static void Main()
        {
            var serviceProvider = ConfigureServices();

            var engine = new Engine(serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<EmployeesDbContext>(options =>
            options.UseSqlServer(Config.ConnectionString));

            serviceCollection.AddTransient<DatabaseInitializerService>();
            //serviceCollection.AddTransient<EmployeeService>();

            //serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<EmployeesProfile>());

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
