namespace BankAccount
{
    public class StartUp
    {
        public static void Main()
        {
            BankAccount acc = new BankAccount();

            acc.Id = 1;
            acc.Deposit(15);
            acc.Withdraw(5);

            System.Console.WriteLine(acc.ToString());
        }
    }
}