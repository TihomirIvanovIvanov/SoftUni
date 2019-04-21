namespace BT.Data.Models
{
    public class BusStation
    {
        public int BusStationId { get; set; }
        public string Name { get; set; }

        public Town Town { get; set; }
        public int TownId { get; set; }
    }
}
