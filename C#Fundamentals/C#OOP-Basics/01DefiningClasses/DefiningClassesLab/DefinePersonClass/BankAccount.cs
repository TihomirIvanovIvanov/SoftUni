namespace BankAccount
{
    public class BankAccount
    {
        private int id;
        private decimal balance;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public override string ToString()
        {
            return $"Account ID{this.id}, balance {this.balance:F2}";
        }
    }
}