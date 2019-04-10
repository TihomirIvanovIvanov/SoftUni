namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    var ex = new NullReferenceException($"{nameof(this.Name)} cannot be empty");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    var ex = new ArgumentException($"{nameof(this.Money)} cannot be negative");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                this.money = value;
            }
        }

        public List<Product> BagOfProducts
        {
            get => this.bagOfProducts;
            private set { this.bagOfProducts = value; }
        }

        public void BuyProduct(Product product)
        {
            var cost = product.Cost;
            if (cost > this.Money)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                this.BagOfProducts.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
        }

        public override string ToString()
        {
            if (this.BagOfProducts.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }
            else
            {
                return $"{this.Name} - {string.Join(", ", this.BagOfProducts)}";
            }
        }
    }
}