namespace PizzaCalories
{
    using Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var pizzaName = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
                var pizza = new Pizza(pizzaName);

                var dough = CreateDough();

                pizza.SetDough(dough);

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    CreateTopping(input, pizza);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private static Dough CreateDough()
        {
            var doughInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var flourType = doughInput[1];
            var bakingTechnique = doughInput[2];
            var doughWeight = double.Parse(doughInput[3]);

            var dough = new Dough(flourType, bakingTechnique, doughWeight);
            return dough;
        }

        private static void CreateTopping(string input, Pizza pizza)
        {
            var toppingInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var toppingType = toppingInput[1];
            var toppingWeight = double.Parse(toppingInput[2]);

            var topping = new Topping(toppingType, toppingWeight);

            pizza.AddTopping(topping);
        }
    }
}