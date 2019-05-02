namespace AnimalCentre.Models.Animals
{
    using Contracts;
    using System;

    public abstract class Animal : IAnimal
    {
        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner = "Centre";
        private bool isAdopt;
        private bool isChipped;
        private bool isVaccinated;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
        }

        public string Name { get => this.name; private set => this.name = value; }

        public int Happiness
        {
            get => this.happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                this.happiness = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                this.energy = value;
            }
        }

        public int ProcedureTime { get => this.procedureTime; set => this.procedureTime = value; }

        public string Owner { get => this.owner; set => this.owner = value; }

        public bool IsAdopt { get => this.isAdopt; set => this.isAdopt = value; }

        public bool IsChipped { get => this.isChipped; set => this.isChipped = value; }

        public bool IsVaccinated { get => this.isVaccinated; set => this.isVaccinated = value; }

        public override string ToString()
        {
            return "    Animal type: {0} - {1} - Happiness: {2} - Energy: {3}";
        }
    }
}