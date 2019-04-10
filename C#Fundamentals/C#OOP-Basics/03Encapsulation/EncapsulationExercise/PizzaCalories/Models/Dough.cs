namespace PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Dough
    {
        private const int minWeight = 1;
        private const int maxWeight = 200;
        private const int defaultMultiplier = 2;

        private Dictionary<string, double> validFlourTypes =
            new Dictionary<string, double>
            {
                ["white"] = 1.5,
                ["wholegrain"] = 1.0,
            };
        private Dictionary<string, double> validBakingTechnique =
            new Dictionary<string, double>
            {
                ["crispy"] = 0.9,
                ["chewy"] = 1.1,
                ["homemade"] = 1.0
            };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private double FlourMultiplier => validFlourTypes[this.FlourType];

        private double BakingTechniqueMultiplier => validBakingTechnique[this.BakingTechnique];

        public double Calories => defaultMultiplier * this.Weight * FlourMultiplier * BakingTechniqueMultiplier;

        public string FlourType
        {
            get => this.flourType;
            set
            {
                ValidateTypes(value, validFlourTypes);
                this.flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                ValidateTypes(value, validBakingTechnique);
                this.bakingTechnique = value.ToLower();
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < minWeight || value > maxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{minWeight}..{maxWeight}].");
                }
                this.weight = value;
            }
        }

        private static void ValidateTypes(string type, Dictionary<string, double> keyValuePairs)
        {
            if (!keyValuePairs.Any(x => x.Key == type.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }
    }
}