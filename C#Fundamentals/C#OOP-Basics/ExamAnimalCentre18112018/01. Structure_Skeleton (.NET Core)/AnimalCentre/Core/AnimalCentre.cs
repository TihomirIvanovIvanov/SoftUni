namespace AnimalCentre.Core
{
    using Factories;
    using Models.Contracts;
    using Models.Hotels;
    using Models.Procedures;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AnimalCentre
    {
        private AnimalFactory animalFactory;

        private IHotel hotel;
        private IDictionary<string, IProcedure> procedures;
        private Dictionary<string, List<string>> adoptedAnimals;

        public AnimalCentre()
        {
            this.animalFactory = new AnimalFactory();

            this.hotel = new Hotel();
            this.procedures = new Dictionary<string, IProcedure>();
            this.adoptedAnimals = new Dictionary<string, List<string>>();

            InitializeProcedures();
        }

        private void InitializeProcedures()
        {
            procedures.Add("Chip", new Chip());
            procedures.Add("DentalCare", new DentalCare());
            procedures.Add("Fitness", new Fitness());
            procedures.Add("NailTrim", new NailTrim());
            procedures.Add("Play", new Play());
            procedures.Add("Vaccinate", new Vaccinate());
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animal = this.animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);
            this.hotel.Accommodate(animal);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            var currentAnimal = this.hotel.Animals[name];
            this.CheckAnimalsExist(currentAnimal);

            this.procedures["Chip"].DoService(currentAnimal, procedureTime);
            return $"{currentAnimal.Name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            var currentAnimal = this.hotel.Animals[name];
            this.CheckAnimalsExist(currentAnimal);

            this.procedures["Vaccinate"].DoService(currentAnimal, procedureTime);
            return $"{currentAnimal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            var currentAnimal = this.hotel.Animals[name];
            this.CheckAnimalsExist(currentAnimal);

            this.procedures["Fitness"].DoService(currentAnimal, procedureTime);
            return $"{currentAnimal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            var currentAnimal = this.hotel.Animals[name];
            this.CheckAnimalsExist(currentAnimal);

            this.procedures["Play"].DoService(currentAnimal, procedureTime);
            return $"{currentAnimal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            var currentAnimal = this.hotel.Animals[name];
            this.CheckAnimalsExist(currentAnimal);

            this.procedures["DentalCare"].DoService(currentAnimal, procedureTime);
            return $"{currentAnimal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            var currentAnimal = this.hotel.Animals[name];
            this.CheckAnimalsExist(currentAnimal);

            this.procedures["NailTrim"].DoService(currentAnimal, procedureTime);
            return $"{currentAnimal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            if (!this.hotel.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            var currentAnimal = this.hotel.Animals[animalName] ?? null;
            this.hotel.Adopt(animalName, owner);

            if (!this.adoptedAnimals.ContainsKey(owner))
            {
                this.adoptedAnimals.Add(owner, new List<string>());
                this.adoptedAnimals[owner].Add(animalName);
            }
            else
            {
                this.adoptedAnimals[owner].Add(animalName);
            }

            if (currentAnimal.IsChipped)
            {
                return $"{currentAnimal.Owner} adopted animal with chip";
            }
            else
            {
                return $"{currentAnimal.Owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            string output = string.Empty;
            switch (type)
            {
                case "Chip":
                    output = procedures["Chip"].History();
                    break;
                case "DentalCare":
                    output = procedures["DentalCare"].History();
                    break;
                case "Play":
                    output = procedures["Play"].History();
                    break;
                case "Vaccinate":
                    output = procedures["Vaccinate"].History();
                    break;
                case "Fitness":
                    output = procedures["Fitness"].History();
                    break;
                case "NailTrim":
                    output = procedures["NailTrim"].History();
                    break;
            }
            return output;
        }

        public string AdoptedAnimals()
        {
            var sb = new StringBuilder();

            foreach (var animal in this.adoptedAnimals.OrderBy(a => a.Key))
            {
                sb.AppendLine($"--Owner: {animal.Key}");
                sb.AppendLine($"    - Adopted animals: {string.Join(' ', animal.Value)}");
            }

            return sb.ToString().TrimEnd();
        }

        private void CheckAnimalsExist(IAnimal currentAnimal)
        {
            if (currentAnimal == null)
            {
                throw new ArgumentException("Current animal does not exits");
            }
        }
    }
}