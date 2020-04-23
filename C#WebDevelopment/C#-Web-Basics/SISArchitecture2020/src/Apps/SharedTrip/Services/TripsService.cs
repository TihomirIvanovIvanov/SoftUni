using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
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

        public void Add(AddInputModel input)
        {
            var departureTime = DateTime
                .ParseExact(input.DepartureTime, "dd.MM.yyyy HH:mm", null);

            var trip = new Trip
            {
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                DepartureTime = departureTime,
                ImagePath = input.ImagePath,
                Seats = input.Seats,
                Description = input.Description,
            };

            this.dbContext.Trips.Add(trip);
            this.dbContext.SaveChanges();
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            var trip = this.GetById(tripId);
            var user = this.dbContext.Users.FirstOrDefault(u => u.Id == userId);

            var userTrips = new UserTrip
            {
                UserId = user.Id,
                TripId = trip.Id,
            };

            if (this.dbContext.UserTrips.Any(ut => ut.UserId == user.Id))
            {
                return;
            }

            this.dbContext.UserTrips.Add(userTrips);
            trip.Seats--;
            this.dbContext.SaveChanges();
        }

        public IQueryable<Trip> AllTrips()
        {
            var trips = this.dbContext.Trips.AsQueryable();
            return trips;
        }

        public Trip GetById(string tripId)
        {
            var trip = this.dbContext.Trips
                .FirstOrDefault(t => t.Id == tripId);

            return trip;
        }
    }
}
