using System;

namespace BankAccount
{
    public class StartUp
    {
        public static void Main()
        {
            var acc = new BankAccount();

            acc.Id = 1;
            acc.Balance = 15;

            Console.WriteLine($"Account {acc.Id}, balance {acc.Balance}");
        }
    }
}
