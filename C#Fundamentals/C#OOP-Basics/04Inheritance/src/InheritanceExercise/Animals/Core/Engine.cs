namespace Animals.Core
{
    using Factories;
    using Models;
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private AnimalFactory animalFactory;

        private List<Animal> animals;

        public Engine()
        {
            this.animalFactory = new AnimalFactory();
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    var type = input;
                    var animalsInfo = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    var name = animalsInfo[0];
                    var age = int.Parse(animalsInfo[1]);
                    var gender = animalsInfo[2];

                    var animal = this.animalFactory.CreateAnimal(type, name, age, gender);
                    animals.Add(animal);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Print();
        }

        private void Print()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal);
                animal.ProduceSound();
            }
        }
    }
}