using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }
        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var allTrips = this.tripsService.GetAllTrips();

            return this.View(new AllTripsListViewModel { Trips = allTrips });
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CreateInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.StartPoint))
            {
                return this.Redirect("/Trips/Add");
            }

            if (string.IsNullOrWhiteSpace(input.EndPoint))
            {
                return this.Redirect("/Trips/Add");
            }

            if (string.IsNullOrWhiteSpace(input.DepartureTime))
            {
                return this.Redirect("/Trips/Add");
            }

            if (input.Seats < 2 || input.Seats > 6)
            {
                return this.Redirect("/Trips/Add");
            }

            if (input.Description.Length > 80)
            {
                return this.Redirect("/Trips/Add");
            }

            this.tripsService.Create(input.StartPoint, input.EndPoint, input.DepartureTime, input.ImagePath, input.Seats, input.Description);

            return this.Redirect("/Trips/All");
        }
    }
}
