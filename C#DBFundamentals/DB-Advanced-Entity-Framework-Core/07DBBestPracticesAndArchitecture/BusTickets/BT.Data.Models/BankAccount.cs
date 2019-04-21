using System.Collections.Generic;

namespace BT.Data.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
