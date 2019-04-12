using System;
using System.Collections.Generic;

namespace DefinePersonClass
{
    public class StartUp
    {
        public static void Main()
        {
            BankAccount acc = new BankAccount();

            acc.ID = 1;
            acc.Balance = 15;

            var accounts = new Dictionary<int, BankAccount>();
            var input = Console.ReadLine().Trim();

            while (input != "End")
            {
                var cmdArgs = input.Split();
                var command = cmdArgs[0];

                switch (command)
                {
                    case "Create":
                        Create(cmdArgs, accounts);
                        break;

                    case "Deposit":
                        Deposit(cmdArgs, accounts);
                        break;

                    case "Withdraw":
                        Withdraw(cmdArgs, accounts);
                        break;

                    case "Print":
                        Print(cmdArgs, accounts);
                        break;
                }

                input = Console.ReadLine().Trim();
            }
        }

        private static void Print(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                Console.WriteLine(accounts[id].ToString());
            }
        }

        private static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);
            var amount = double.Parse(cmdArgs[2]);

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                if (amount > accounts[id].Balance)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    accounts[id].Withdraw(amount);
                }
            }
        }

        private static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);
            var amount = double.Parse(cmdArgs[2]);

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                accounts[id].Deposit(amount);
            }
        }

        private static void Create(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);

            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                var acc = new BankAccount();
                acc.ID = id;
                accounts.Add(id, acc);
            }
        }
    }
}
