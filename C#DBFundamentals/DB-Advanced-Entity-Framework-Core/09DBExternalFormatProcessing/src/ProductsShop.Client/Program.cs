using System;
using ProductsShop.Data;
using ProductsShop.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ProductsShop.Client
{
    public class Program
    {
        public static void Main()
        {
            using (var context = new ProductsShopContext())
            {
                SeedJson(context);
            }
        }

        private static void SeedJson(ProductsShopContext context)
        {
            var users = ImportUsersJson();
            context.Users.AddRange(users);

            var categories = ImportCategoriesJson();
            context.Categories.AddRange(categories);

            var products = ImportProductsJson(context);
            context.Products.AddRange(products);

            context.SaveChanges();
        }

        private static Product[] ImportProductsJson(ProductsShopContext context)
        {
            var json = File.ReadAllText(@"C:\Users\tihom\source\SoftUniCoursesCSharp\00GitAndGitHub\SoftUni\C#DBFundamentals\DB-Advanced-Entity-Framework-Core\09DBExternalFormatProcessing\src\ProductsShop.Client\Import\products.json");

            var products = JsonConvert.DeserializeObject<Product[]>(json);

            var users = context.Users.ToArray();

            var random = new Random();

            foreach (var product in products)
            {
                var seller = users[random.Next(0, users.Length)];
                product.Seller = seller;

                var bayerId = random.Next(0, users.Length + (int)(users.Length * 0.3));
                product.Buyer = bayerId < users.Length ? users[bayerId] : null;
            }

            return products;
        }

        private static Category[] ImportCategoriesJson()
        {
            var json = File.ReadAllText(@"C:\Users\tihom\source\SoftUniCoursesCSharp\00GitAndGitHub\SoftUni\C#DBFundamentals\DB-Advanced-Entity-Framework-Core\09DBExternalFormatProcessing\src\ProductsShop.Client\Import\categories.json");

            var categories = JsonConvert.DeserializeObject<Category[]>(json);

            return categories;
        }

        private static User[] ImportUsersJson()
        {
            var json = File.ReadAllText(@"C:\Users\tihom\source\SoftUniCoursesCSharp\00GitAndGitHub\SoftUni\C#DBFundamentals\DB-Advanced-Entity-Framework-Core\09DBExternalFormatProcessing\src\ProductsShop.Client\Import\users.json");
            var users = JsonConvert.DeserializeObject<User[]>(json);

            return users;
        }
    }
}
