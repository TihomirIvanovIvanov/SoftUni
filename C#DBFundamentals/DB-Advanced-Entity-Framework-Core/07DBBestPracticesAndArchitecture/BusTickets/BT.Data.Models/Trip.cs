using System;
using System.Collections.Generic;

namespace BT.Data.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public StatusType Status { get; set; }
        public string OriginBusStation { get; set; }
        public string DestinationBusStation { get; set; }

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public int BusCompanyId { get; set; }
        public BusCompany BusCompany { get; set; }
    }
}