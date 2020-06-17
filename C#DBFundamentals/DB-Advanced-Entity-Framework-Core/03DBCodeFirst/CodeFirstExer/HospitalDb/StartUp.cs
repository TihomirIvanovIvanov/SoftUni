using HospitalDb.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalDb
{
    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new HospitalDbContext();
            dbContext.Database.Migrate();
        }
    }
}
