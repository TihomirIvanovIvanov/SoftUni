using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private const string DepartureTimeFormat = "dd.MM.yyyy HH:mm";

        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string startPoint, string endPoint, string departureTime, string imagePath, int seats, string description)
        {
            var trip = new Trip
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                DepartureTime = DateTime.ParseExact(departureTime, DepartureTimeFormat, CultureInfo.InvariantCulture),
                ImagePath = imagePath,
                Seats = seats,
                Descrtiption = departureTime,
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public IQueryable<AllTripsViewModel> GetAllTrips()
        {
            var trips = this.db.Trips.Select(t =>
                new AllTripsViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString(DepartureTimeFormat),
                    Seats = t.Seats
                }).AsQueryable();

            return trips;
        }

        public DetailsViewModel GetDetails(string id)
        {
            var trips = this.db.Trips.FirstOrDefault(t => t.Id == id);

            var details = new DetailsViewModel
            {
                Id = trips.Id,
                ImagePath = trips.ImagePath,
                StartPoint = trips.StartPoint,
                EndPoint = trips.EndPoint,
                DepartureTime = trips.DepartureTime,
                Seats = trips.Seats,
                Description = trips.Descrtiption
            };

            return details;
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            var trip = this.db.Trips.FirstOrDefault(t => t.Id == tripId);
            var user = this.db.Users.FirstOrDefault(u => u.Id == userId);

            var userToTrip = new UserTrip
            {
                UserId = user.Id,
                TripId = trip.Id
            };

            if (this.db.UserTrips.Any(ut => ut.UserId == user.Id))
            {
                return;
            }

            this.db.UserTrips.Add(userToTrip);
            trip.Seats--;
            this.db.SaveChanges();
        }
    }
}
