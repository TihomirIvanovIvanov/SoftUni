namespace Threeuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] nameAddressTown = Console.ReadLine().Split();
            string name = nameAddressTown[0] + " " + nameAddressTown[1];
            string address = nameAddressTown[2];
            string town = nameAddressTown[3];
            SpecialTuple<string, string, string> nameAddressTownTuple = new SpecialTuple<string, string, string>(name, address, town);
            Console.WriteLine(nameAddressTownTuple);

            string[] nameLitersDrunk = Console.ReadLine().Split();
            name = nameLitersDrunk[0];
            int liters = int.Parse(nameLitersDrunk[1]);
            bool isDrunk = nameLitersDrunk[2].Equals("drunk");
            SpecialTuple<string, int, bool> nameLitersDrunkTuple = new SpecialTuple<string, int, bool>(name, liters, isDrunk);
            Console.WriteLine(nameLitersDrunkTuple);

            string[] nameBalanceBank = Console.ReadLine().Split();
            name = nameBalanceBank[0];
            double balance = double.Parse(nameBalanceBank[1]);
            string bankName = nameBalanceBank[2];
            SpecialTuple<string, double, string> nameBalanceBankTuple = new SpecialTuple<string, double, string>(name, balance, bankName);
            Console.WriteLine(nameBalanceBankTuple);
        }
    }
}