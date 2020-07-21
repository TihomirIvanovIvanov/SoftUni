namespace FastFood.Models
{
    public class OrderItem
    {
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int ItemId { get; set; }

        public virtual Item Item { get; set; }

        public int Quantity { get; set; }
    }
}