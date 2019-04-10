namespace PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private const int minLenght = 0;
        private const int maxLenght = 15;
        private const int minToppings = 0;
        private const int maxToppings = 10;
        
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza()
        {
            this.Toppings = new List<Topping>();
        }

        public Pizza(string name)
            : this()
        {
            this.Name = name;
        }

        private double ToppingsCalories
        {
            get
            {
                if (this.Toppings.Count == 0)
                {
                    return 0;
                }

                return this.Toppings.Select(t => t.Calories).Sum();
            }
        }

        private double Calories => this.Dough.Calories + this.ToppingsCalories;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > maxLenght)
                {
                    throw new ArgumentException($"Pizza name should be between {minLenght} and {maxLenght} symbols.");
                }
                this.name = value;
            }
        }

        private Dough Dough
        {
            get => this.dough;
            set
            {
                this.dough = value;
            }
        }
        
        private List<Topping> Toppings
        {
            get => this.toppings;
            set
            {
                this.toppings = value;
            }
        }

        public void SetDough(Dough dough)
        {
            if (this.Dough != null)
            {
                throw new InvalidOperationException($"Dough already set!");
            }
            this.Dough = dough;
        }

        public void AddTopping(Topping topping)
        {
            this.Toppings.Add(topping);
            if (this.Toppings.Count > maxToppings)
            {
                throw new ArgumentException($"Number of toppings should be in range [{minLenght}..{maxToppings}].");
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:F2} Calories.";
        }
    }
}