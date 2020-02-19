using SharedTrip.ViewModels.Trips;
using System.Linq;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        IQueryable<AllTripsViewModel> GetAllTrips();
    }
}
