using SharedTrip.Models;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext dbContext;

        public TripsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Trip> AllTrips()
        {
            var trips = this.dbContext.Trips.AsQueryable();
            return trips;
        }
    }
}
