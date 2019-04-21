namespace BT.Data.Models
{
    using System;

    public class Review
    {
        public int ReviewId { get; set; }
        public string Content { get; set; }
        public float Grade { get; set; }
        public DateTime Publishing { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int BusCompanyId { get; set; }
        public BusCompany BusCompany { get; set; }

        public int BusStationId { get; set; }
        public BusStation BusStation { get; set; }
    }
}
