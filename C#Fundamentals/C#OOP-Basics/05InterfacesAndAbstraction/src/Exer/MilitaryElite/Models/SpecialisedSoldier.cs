namespace MilitaryElite.Models
{
    using Contracts;
    using Enums;
    using System;
    using System.Text;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private Corps corps;

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get { return this.corps.ToString(); }
            private set
            {
                Corps corps;

                if (!Enum.TryParse<Corps>(value, out corps))
                {
                    throw new ArgumentException();
                }
                this.corps = corps;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(base.ToString())
                .AppendLine($"Corps: {this.Corps}");

            return builder.ToString().TrimEnd();
        }
    }
}
