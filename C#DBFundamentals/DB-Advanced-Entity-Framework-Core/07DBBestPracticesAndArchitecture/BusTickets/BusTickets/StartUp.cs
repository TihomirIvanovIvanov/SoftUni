using BusTicketsData;

namespace BusTickets
{
    public class StartUp
    {
        static void Main()
        {
            using (var context = new BusTicketContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}
