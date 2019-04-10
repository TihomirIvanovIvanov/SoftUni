using System;
using System.Collections.Generic;

public class StartUp
{
    private static Dictionary<int, BankAccount> accounts;

    public static void Main()
    {
        accounts = new Dictionary<int, BankAccount>();
        string cmd;

        while ((cmd = Console.ReadLine()) != "End")
        {
            var command = cmd.Split();
            var commandType = command[0];

            switch (commandType)
            {
                case "Create":
                    Create(command);
                    break;
                case "Deposit":
                    Deposit(command);
                    break;
                case "Withdraw":
                    Withdraw(command);
                    break;
                case "Print":
                    Print(command);
                    break;
            }
        }
    }

    private static void Print(string[] command)
    {
        var id = int.Parse(command[1]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            var currentAcc = accounts[id];
            Console.WriteLine(currentAcc);
        }
    }

    private static void Withdraw(string[] command)
    {
        var id = int.Parse(command[1]);
        var amount = double.Parse(command[2]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else if (accounts.ContainsKey(id) && accounts[id].Balance < amount)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            var currentAcc = accounts[id];
            currentAcc.Balance -= amount;
        }
    }

    private static void Deposit(string[] command)
    {
        var id = int.Parse(command[1]);
        var amount = double.Parse(command[2]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            var currentAcc = accounts[id];
            currentAcc.Balance += amount;
        }
    }

    private static void Create(string[] command)
    {
        var id = int.Parse(command[1]);

        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount { ID = id };
            accounts.Add(id, acc);
        }
    }
}