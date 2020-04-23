using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System.Linq;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        IQueryable<Trip> AllTrips();

        void Add(AddInputModel input);

        Trip GetById(string tripId);

        void AddUserToTrip(string tripId, string userId);
    }
}
