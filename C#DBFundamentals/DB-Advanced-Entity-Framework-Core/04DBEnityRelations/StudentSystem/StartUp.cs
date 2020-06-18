using StudentSystem.Data;

namespace StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new StudentSystemContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}
