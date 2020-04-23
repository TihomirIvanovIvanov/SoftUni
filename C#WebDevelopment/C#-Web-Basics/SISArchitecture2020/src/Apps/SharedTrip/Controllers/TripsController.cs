using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Globalization;
using System.Linq;

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

            var tripsViewModel = this.tripsService.AllTrips()
                .Select(t => new AllViewModels 
                { 
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime,
                    Seats = t.Seats
                }).ToArray();

            return this.View(tripsViewModel);
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
        public HttpResponse Add(AddInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.StartPoint))
            {
                return this.Add(input);
            }

            if (string.IsNullOrWhiteSpace(input.EndPoint))
            {
                return this.Add(input);
            }

            if (string.IsNullOrWhiteSpace(input.DepartureTime))
            {
                return this.Add(input);
            }

            if (input.Seats < 2 || input.Seats > 6)
            {
                return this.Add(input);
            }

            if (input.Description.Length > 80)
            {
                return this.Add(input);
            }

            this.tripsService.Add(input);

            return this.All();
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trip = this.tripsService.GetById(tripId);
            var tripDetailsView = new DetailsViewModel
            {
                Id = trip.Id,
                ImagePath = trip.ImagePath,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = trip.DepartureTime,
                Seats = trip.Seats,
                Description = trip.Description,
            };

            return this.View(tripDetailsView);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.User;
            this.tripsService.AddUserToTrip(tripId, userId);

            return this.All();
        }
    }
}
