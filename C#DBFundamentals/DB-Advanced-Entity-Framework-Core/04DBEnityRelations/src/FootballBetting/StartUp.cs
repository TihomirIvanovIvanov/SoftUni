using FootballBetting.Data;

namespace FootballBetting
{
    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new FootballBettingContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}
