namespace Tuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] nameAndAddress = Console.ReadLine().Split();
            string name = nameAndAddress[0] + " " + nameAndAddress[1];
            string address = nameAndAddress[2];
            SpecialTuple<string, string> nameAndAddressTupple = new SpecialTuple<string, string>(name, address);
            Console.WriteLine(nameAndAddressTupple);

            string[] nameAndLiters = Console.ReadLine().Split();
            name = nameAndLiters[0];
            int liters = int.Parse(nameAndLiters[1]);
            SpecialTuple<string, int> nameAndLitersTuple = new SpecialTuple<string, int>(name, liters);
            Console.WriteLine(nameAndLitersTuple);

            string[] intAndDoubleNums = Console.ReadLine().Split();
            int intNum = int.Parse(intAndDoubleNums[0]);
            double doubleNum = double.Parse(intAndDoubleNums[1]);
            SpecialTuple<int, double> intAndDoubleTuple = new SpecialTuple<int, double>(intNum, doubleNum);
            Console.WriteLine(intAndDoubleTuple);
        }
    }
}