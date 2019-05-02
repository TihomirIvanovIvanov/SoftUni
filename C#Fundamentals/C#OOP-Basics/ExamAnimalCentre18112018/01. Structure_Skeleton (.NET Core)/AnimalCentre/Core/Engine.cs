namespace AnimalCentre.Core
{
    using System;
    using System.Linq;

    public class Engine
    {
        private AnimalCentre animalCentre;

        public Engine()
        {
            this.animalCentre = new AnimalCentre();
        }

        public void Run()
        {
            string input;
            string result = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var commandArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var command = commandArgs[0];

                try
                {
                    switch (command)
                    {
                        case "RegisterAnimal":
                            result = this.animalCentre.RegisterAnimal(commandArgs[1], commandArgs[2], int.Parse(commandArgs[3]), int.Parse(commandArgs[4]), int.Parse(commandArgs[5]));
                            break;
                        case "Chip":
                            result = this.animalCentre.Chip(commandArgs[1], int.Parse(commandArgs[2]));
                            break;
                        case "Vaccinate":
                            result = this.animalCentre.Vaccinate(commandArgs[1], int.Parse(commandArgs[2]));
                            break;
                        case "Fitness":
                            result = this.animalCentre.Fitness(commandArgs[1], int.Parse(commandArgs[2]));
                            break;
                        case "Play":
                            result = this.animalCentre.Play(commandArgs[1], int.Parse(commandArgs[2]));
                            break;
                        case "DentalCare":
                            result = this.animalCentre.DentalCare(commandArgs[1], int.Parse(commandArgs[2]));
                            break;
                        case "NailTrim":
                            result = this.animalCentre.NailTrim(commandArgs[1], int.Parse(commandArgs[2]));
                            break;
                        case "Adopt":
                            result = this.animalCentre.Adopt(commandArgs[1], commandArgs[2]);
                            break;
                        case "History":
                            result = this.animalCentre.History(commandArgs[1]);
                            break;
                    }

                    Console.WriteLine(result);

                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine($"InvalidOperationException: {ioe.Message}");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine($"ArgumentException: {ae.Message}");
                }
            }
            Console.WriteLine(this.animalCentre.AdoptedAnimals());
        }        
    }
}