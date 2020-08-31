using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main()
        {
            var personInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            var productInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            var people = new List<Person>();
            var products = new List<Product>();

            for (int i = 0; i < personInput.Length; i++)
            {
                var personInfo = personInput[i].Split('=');
                var name = personInfo[0];
                var money = decimal.Parse(personInfo[1]);

                var person = new Person(name, money);
                people.Add(person);
            }

            for (int i = 0; i < productInput.Length; i++)
            {
                var productInfo = productInput[i].Split('=');
                var name = productInfo[0];
                var cost = decimal.Parse(productInfo[1]);

                var product = new Product(name, cost);
                products.Add(product);
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var personName = inputArgs[0];
                var productName = inputArgs[1];

                var product = products
                    .First(product => product.Name == productName);
                people
                    .First(person => person.Name == personName)
                    .BuyProduct(product);
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
