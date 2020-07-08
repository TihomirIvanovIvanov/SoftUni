namespace PhotoShare.Client
{
    using Core;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PhotoShare.Services;
    using System;

    public class Application
    {
        public static void Main()
        {
            var serviceProvider = ConfigureServices();

            Engine engine = new Engine(serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<PhotoShareContext>(options =>
                options.UseSqlServer("Server=.;Database=PhotoShare;Trusted_Connection=True"));

            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
            serviceCollection.AddTransient<IUsersService, UsersService>();
            serviceCollection.AddTransient<ITownsService, TownsService>();
            serviceCollection.AddTransient<IAlbumsService, AlbumsService>();
            serviceCollection.AddTransient<IFriendshipService, FriendshipService>();

            serviceCollection.AddSingleton<IUsersSessionService, UsersSessionService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
