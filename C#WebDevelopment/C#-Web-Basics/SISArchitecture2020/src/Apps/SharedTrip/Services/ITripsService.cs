using SharedTrip.Models;
using System.Linq;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        IQueryable<Trip> AllTrips();
    }
}
