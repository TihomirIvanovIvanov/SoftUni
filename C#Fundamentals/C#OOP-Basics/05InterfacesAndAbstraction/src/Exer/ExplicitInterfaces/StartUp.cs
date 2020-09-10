namespace ExplicitInterfaces
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var personInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var name = personInfo[0];
                var country = personInfo[1];
                var age = int.Parse(personInfo[2]);

                var citizen = new Citizen(name, age, country);

                Console.WriteLine(citizen.PrintName());
                Console.WriteLine(((IResident)citizen).PrintName());
            }
        }
    }
}