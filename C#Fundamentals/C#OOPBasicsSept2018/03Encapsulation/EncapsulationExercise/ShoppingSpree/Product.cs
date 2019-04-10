namespace ShoppingSpree
{
    using System;

    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    var ex = new ArgumentException($"{nameof(this.Name)} cannot be empty");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                this.name = value;
            }
        }

        public decimal Cost
        {
            get => this.cost;
            private set
            {
                if (value < 0)
                {
                    var ex = new ArgumentException($"Money cannot be negative");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}