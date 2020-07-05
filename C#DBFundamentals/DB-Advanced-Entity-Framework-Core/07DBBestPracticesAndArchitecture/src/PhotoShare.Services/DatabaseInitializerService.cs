namespace PhotoShare.Services
{
    using PhotoShare.Data;

    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly PhotoShareContext context;

        public DatabaseInitializerService(PhotoShareContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.EnsureCreated();
        }
    }
}
