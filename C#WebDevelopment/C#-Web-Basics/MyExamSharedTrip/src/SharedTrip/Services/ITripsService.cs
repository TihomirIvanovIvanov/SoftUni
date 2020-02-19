using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System.Linq;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        IQueryable<AllTripsViewModel> GetAllTrips();

        void Create(string startPoint, string endPoint, string departureTime, string imagePath, int seats, string description);

        DetailsViewModel GetDetails(string tripId);
    }
}
