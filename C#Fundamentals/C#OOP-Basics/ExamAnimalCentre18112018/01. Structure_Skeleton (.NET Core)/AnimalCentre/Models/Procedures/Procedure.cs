namespace AnimalCentre.Models.Procedures
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Procedure : IProcedure
    {
        protected IList<IAnimal> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        public string History()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);

            var animalsInfo = this.procedureHistory
                .OrderBy(a => a.Name)
                .Select(a => a.ToString())
                .ToArray();

            sb.AppendLine(string.Join(Environment.NewLine, animalsInfo));

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public abstract void DoService(IAnimal animal, int procedureTime);

        protected void CheckIfTimeIsEnought(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException($"Animal doesn't have enough procedure time");
            }

            animal.ProcedureTime -= procedureTime;
        }
    }
}
