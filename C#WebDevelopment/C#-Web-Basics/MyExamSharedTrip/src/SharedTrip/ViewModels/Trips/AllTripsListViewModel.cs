using System.Collections.Generic;

namespace SharedTrip.ViewModels.Trips
{
    public class AllTripsListViewModel
    {
        public IEnumerable<AllTripsViewModel> Trips { get; set; }
    }
}
