using SharedTrip.ViewModels.Trips;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IQueryable<AllTripsViewModel> GetAllTrips()
        {
            var trips = this.db.Trips.Select(t =>
                new AllTripsViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString(),
                    Seats = t.Seats
                }).AsQueryable();

            return trips;
        }
    }
}
