﻿namespace AnimalCentre.Models.Procedures
{
    using Contracts;

    public class Fitness : Procedure
    {
        private const int RemoveHappiness = 3;
        private const int AddEnergy = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckIfTimeIsEnought(animal, procedureTime);

            animal.Happiness -= RemoveHappiness;
            animal.Energy += AddEnergy;
            
            base.procedureHistory.Add(animal);
        }
    }
}
