namespace FootballTeamGenerator.Models
{
    using System;

    public class Stat
    {
        private const int minLevel = 0;
        private const int maxLevel = 100;

        private string name;
        private int level;

        public Stat(string name, int level)
        {
            this.Name = name;
            this.Level = level;
        }

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
            }
        }

        public int Level
        {
            get => level;
            set
            {
                if (value < minLevel || value > maxLevel)
                {
                    throw new ArgumentException($"{this.Name} should be between {minLevel} and {maxLevel}.");
                }
                this.level = value;
            }
        }
    }
}