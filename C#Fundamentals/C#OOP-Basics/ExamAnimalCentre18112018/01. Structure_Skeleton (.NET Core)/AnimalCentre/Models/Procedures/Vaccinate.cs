namespace AnimalCentre.Models.Procedures
{
    using Contracts;

    public class Vaccinate : Procedure
    {
        private const int RemoveEnergy = 8;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckIfTimeIsEnought(animal, procedureTime);

            animal.Energy -= RemoveEnergy;

            animal.IsVaccinated = true;

            base.procedureHistory.Add(animal);
        }
    }
}
