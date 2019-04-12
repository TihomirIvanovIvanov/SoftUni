using System;

namespace Methods
{
    public class StartUp
    {
        public static void Main()
        {
            BankAccount acc = new BankAccount();

            acc.ID = 1;
            acc.Balance = 15;
            acc.Withdraw(5);

            Console.WriteLine($"Account {acc.ID}, balance {acc.Balance:F2}.");
        }
    }
}
