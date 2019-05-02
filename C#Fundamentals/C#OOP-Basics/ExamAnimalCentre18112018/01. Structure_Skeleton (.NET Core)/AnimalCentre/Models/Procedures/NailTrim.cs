namespace AnimalCentre.Models.Procedures
{
    using Contracts;

    public class NailTrim : Procedure
    {
        private const int RemoveHappiness = 7;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckIfTimeIsEnought(animal, procedureTime);

            animal.Happiness -= RemoveHappiness;
            
            base.procedureHistory.Add(animal);
        }
    }
}