using Andreys.Data;
using Andreys.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string description, string imageUrl, string category, string gender, decimal price)
        {
            var userId = this.db.Users.Select(u => u.Id).FirstOrDefault();

            var product = new Product
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                Category = Enum.Parse<Category>(category),
                Gender = Enum.Parse<Gender>(gender),
                Price = price,
                UserId = userId
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var product = this.db.Products.FirstOrDefault(p => p.Id == id);

            this.db.Products.Remove(product);
            this.db.SaveChanges();
        }

        public Product Details(string id)
        {
            var products = this.db.Products.FirstOrDefault(p => p.Id == id);
            return products;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = this.db.Products;
            return products;
        }
    }
}
