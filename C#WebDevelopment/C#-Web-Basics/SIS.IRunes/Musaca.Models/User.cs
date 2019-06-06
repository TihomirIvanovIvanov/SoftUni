namespace Musaca.Models
{
    using Enums;
    using System.Collections.Generic;

    public class User : BaseModel<int>
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
            this.Receipts = new HashSet<Receipt>();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
