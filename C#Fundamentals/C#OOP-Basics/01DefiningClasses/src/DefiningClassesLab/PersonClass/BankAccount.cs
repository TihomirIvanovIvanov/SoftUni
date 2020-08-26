namespace PersonClass
{
    public class BankAccount
    {
        private int id;

        private decimal balance;

        public int Id { get; set; }

        public decimal Balance { get; set; }

        public override string ToString()
        {
            return $"Account ID{this.id}, balance {this.balance:F2}";
        }
    }
}
