namespace AnimalCentre.Models.Procedures
{
    using Contracts;

    public class Play : Procedure
    {
        private const int RemoveEnergy = 6;
        private const int AddHappiness = 12;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckIfTimeIsEnought(animal, procedureTime);

            animal.Energy -= RemoveEnergy;
            animal.Happiness += AddHappiness;

            base.procedureHistory.Add(animal);
        }
    }
}
