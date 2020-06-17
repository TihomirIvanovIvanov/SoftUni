using HospitalDb.Data;

namespace HospitalDb
{
    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new HospitalDbContext();
            dbContext.Database.EnsureCreated();
        }
    }
}
