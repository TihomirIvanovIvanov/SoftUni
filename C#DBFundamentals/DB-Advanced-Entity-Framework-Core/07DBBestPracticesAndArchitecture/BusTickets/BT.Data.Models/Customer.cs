using System;
using System.Collections.Generic;

namespace BT.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Tickets = new HashSet<Ticket>();
            this.BankAccounts = new HashSet<BankAccount>();
            this.Reviews = new HashSet<Review>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }

        public int TownId { get; set; }
        public Town HomeTown { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<BankAccount> BankAccounts { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}