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
    }
}
