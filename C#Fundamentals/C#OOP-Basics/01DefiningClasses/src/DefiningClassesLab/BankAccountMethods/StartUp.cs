using System;

namespace BankAccountMethods
{
    public class StartUp
    {
        public static void Main()
        {
            var acc = new BankAccount();

            acc.Id = 1;
            acc.Balance = 15;
            acc.Withdraw(10);

            Console.WriteLine(acc);
        }
    }
}
