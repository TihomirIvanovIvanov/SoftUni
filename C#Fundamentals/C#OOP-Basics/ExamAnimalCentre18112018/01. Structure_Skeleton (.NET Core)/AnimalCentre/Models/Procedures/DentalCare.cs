namespace AnimalCentre.Models.Procedures
{
    using Contracts;

    public class DentalCare : Procedure
    {
        private const int AddHappiness = 12;
        private const int AddEnergy = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckIfTimeIsEnought(animal, procedureTime);

            animal.Happiness += AddHappiness;
            animal.Energy += AddEnergy;

            base.procedureHistory.Add(animal);
        }
    }
}