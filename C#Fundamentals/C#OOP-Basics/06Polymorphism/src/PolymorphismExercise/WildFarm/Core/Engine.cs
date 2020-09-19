using System;
using System.Collections.Generic;
using WildFarm.Factories;
using WildFarm.Models;

namespace WildFarm.Core
{
    public class Engine
    {
        private readonly BirdFactory birdFactory;

        private readonly FelineFactory felineFactory;

        private readonly MammalFactory mammalFactory;

        private readonly FoodFactory foodFactory;

        private readonly List<Animal> animals;

        private Animal animal;

        public Engine()
        {
            this.birdFactory = new BirdFactory();
            this.felineFactory = new FelineFactory();
            this.mammalFactory = new MammalFactory();
            this.foodFactory = new FoodFactory();
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    var animalInfo = input
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var foodInfo = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    var animalType = animalInfo[0];
                    var name = animalInfo[1];
                    var weight = double.Parse(animalInfo[2]);

                    if (animalType == "Hen" || animalType == "Owl")
                    {
                        var wingSize = double.Parse(animalInfo[3]);

                        animal = this.birdFactory.Create(animalType, name, weight, wingSize);
                    }
                    else if (animalType == "Mouse" || animalType == "Dog")
                    {
                        var livingRegion = animalInfo[3];

                        animal = this.mammalFactory.Create(animalType, name, weight, livingRegion);
                    }
                    else if (animalType == "Cat" || animalType == "Tiger")
                    {
                        var livingRegion = animalInfo[3];
                        var breed = animalInfo[4];

                        animal = this.felineFactory.Create(animalType, name, weight, livingRegion, breed);
                    }

                    var foodType = foodInfo[0];
                    var quantity = int.Parse(foodInfo[1]);
                    var food = this.foodFactory.Create(foodType, quantity);

                    animal.ProduceSound();
                    animals.Add(animal);
                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
