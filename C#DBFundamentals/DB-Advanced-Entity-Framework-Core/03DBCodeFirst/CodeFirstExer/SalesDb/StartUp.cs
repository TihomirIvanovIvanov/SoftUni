using Microsoft.EntityFrameworkCore;
using SalesDb.Data;

namespace SalesDb
{
    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new SalesDbContext();
            dbContext.Database.Migrate();
        }
    }
}
