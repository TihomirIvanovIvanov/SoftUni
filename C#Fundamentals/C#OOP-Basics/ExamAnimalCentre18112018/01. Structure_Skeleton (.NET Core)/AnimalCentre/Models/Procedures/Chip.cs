﻿namespace AnimalCentre.Models.Procedures
{
    using Contracts;
    using System;

    public class Chip : Procedure
    {
        private const int RemoveHappiness = 5;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckIfTimeIsEnought(animal, procedureTime);

            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            animal.Happiness -= RemoveHappiness;
            animal.IsChipped = true;

            base.procedureHistory.Add(animal);
        }
    }
}