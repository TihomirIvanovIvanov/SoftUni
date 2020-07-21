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
                SeedXml(context);
            }
        }

        private static void SeedXml(ProductsShopContext context)
        {
            var users = ImportUsersXml();
            context.Users.AddRange(users);

            var products = ImportProductsXml(context);
            context.Products.AddRange(products);

            var categories = ImportCategoriesXml();
            context.Categories.AddRange(categories);

            var categoryProducts = CreateCategoryProductsXml(context);
            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();
        }

        private static List<CategoryProduct> CreateCategoryProductsXml(ProductsShopContext context)
        {
            var categoryProducts = new List<CategoryProduct>();
            var products = context.Products.ToList();
            var categories = context.Categories.ToList();
            var random = new Random();

            for (int i = 0; i < products.Count; i++)
            {
                var categoriesCount = random.Next(1, 4);
                var currentCategories = new HashSet<Category>();

                for (int j = 1; j <= categoriesCount; j++)
                {
                    var category = categories[random.Next(0, categories.Count)];
                    currentCategories.Add(category);
                }

                currentCategories.ToList()
                    .ForEach(c => categoryProducts.Add(new CategoryProduct { Category = c, Product = products[i] }));
            }

            return categoryProducts.ToList();
        }

        private static List<Category> ImportCategoriesXml()
        {
            var xDoc = XDocument.Load(@"C:\Users\tihom\source\SoftUniCoursesCSharp\00GitAndGitHub\SoftUni\C#DBFundamentals\DB-Advanced-Entity-Framework-Core\09DBExternalFormatProcessing\src\ProductsShop.Client\Import\categories.xml");

            var elements = xDoc.Root.Elements();

            var categories = new List<Category>();

            foreach (var category in elements)
            {
                var name = category.Element("name").Value;

                categories.Add(new Category { Name = name });
            }

            return categories;
        }

        private static List<Product> ImportProductsXml(ProductsShopContext context)
        {
            var xDoc = XDocument.Load(@"C:\Users\tihom\source\SoftUniCoursesCSharp\00GitAndGitHub\SoftUni\C#DBFundamentals\DB-Advanced-Entity-Framework-Core\09DBExternalFormatProcessing\src\ProductsShop.Client\Import\products.xml");

            var elements = xDoc.Root.Elements();

            var products = new List<Product>();
            var users = context.Users.ToList();

            var random = new Random();

            foreach (var element in elements)
            {
                var name = element.Element("name").Value;
                var price = decimal.Parse(element.Element("price").Value);

                var product = new Product
                {
                    Name = name,
                    Price = price,
                };

                var seller = users[random.Next(0, users.Count)];
                product.Seller = seller;

                var bayerId = random.Next(0, users.Count + (int)(users.Count * 0.3));
                product.Buyer = bayerId < users.Count ? users[bayerId] : null;

                products.Add(product);
            }

            return products;
        }

        private static List<User> ImportUsersXml()
        {
            var xDoc = XDocument.Load(@"C:\Users\tihom\source\SoftUniCoursesCSharp\00GitAndGitHub\SoftUni\C#DBFundamentals\DB-Advanced-Entity-Framework-Core\09DBExternalFormatProcessing\src\ProductsShop.Client\Import\users.xml");

            var elements = xDoc.Root.Elements();

            var users = new List<User>();

            foreach (var user in elements)
            {
                var firstName = user.Attribute("firstName")?.Value;
                var lastName = user.Attribute("lastName")?.Value;

                int? age = null;
                if (user.Attribute("age") != null)
                {
                    age = int.Parse(user.Attribute("age").Value);
                }

                users.Add(new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                });
            }

            return users;
        }

        private static string UsersAndProducts(ProductsShopContext context)
        {
            var users = context.Users
                .Where(u => u.SellingProducts != null)
                .Select(u => new
                {
                    usersCount = u.SellingProducts.Count,
                    users = new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = new
                        {
                            count = u.SellingProducts.Count,
                            products = u.SellingProducts
                            .Select(sp => new
                            {
                                name = sp.Name,
                                price = sp.Price
                            })
                            .ToList()
                        }
                    }
                })
                .OrderByDescending(o => o.users.soldProducts.count)
                .ThenBy(o => o.users.lastName)
                .ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            File.WriteAllText(@"C:\Users\tihom\source\SoftUniCoursesCSharp\00GitAndGitHub\SoftUni\C#DBFundamentals\DB-Advanced-Entity-Framework-Core\09DBExternalFormatProcessing\src\ProductsShop.Client\Export\UsersAndProducts.json", json);

            return json;
        }

        private static string CategoriesByProductsCount(ProductsShopContext context)
        {
            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = c.CategoryProducts.Select(cp => cp.Product.Price).Average(),
                    totalRevenue = c.CategoryProducts.Select(cp => cp.Product.Price).Sum()
                }).ToList();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            File.WriteAllText(
                @"C:\Users\tihom\source\SoftUniCoursesCSharp\00GitAndGitHub\SoftUni\C#DBFundamentals\DB-Advanced-Entity-Framework-Core\09DBExternalFormatProcessing\src\ProductsShop.Client\Export\CategoriesByProductsCount.json", json);

            return json;
        }

        private static string SuccessfullySoldProducts(ProductsShopContext context)
        {
            var users = context.Users
                .Where(u => u.SellingProducts.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.SellingProducts
                        .Where(sp => sp.Buyer != null)
                        .Select(sp => new
                        {
                            name = sp.Name,
                            price = sp.Price,
                            buyerFirstName = sp.Buyer.FirstName,
                            buyerLastName = sp.Buyer.LastName,
                        }).ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            File.WriteAllText(
                @"C:\Users\tihom\source\SoftUniCoursesCSharp\00GitAndGitHub\SoftUni\C#DBFundamentals\DB-Advanced-Entity-Framework-Core\09DBExternalFormatProcessing\src\ProductsShop.Client\Export\SuccessfullySoldProducts.json", json);

            return json;
        }

        private static string GetProductsInRange(ProductsShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}",
                }).ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            File.WriteAllText(@"C:\Users\tihom\source\SoftUniCoursesCSharp\00GitAndGitHub\SoftUni\C#DBFundamentals\DB-Advanced-Entity-Framework-Core\09DBExternalFormatProcessing\src\ProductsShop.Client\Export\GetProductsInRange.json", json);

            return json;
        }

        private static void SeedJson(ProductsShopContext context)
        {
            var users = ImportUsersJson();
            context.Users.AddRange(users);

            var categories = ImportCategoriesJson();
            context.Categories.AddRange(categories);

            //var products = ImportProductsJson(context);
            //context.Products.AddRange(products);

            var categoryProducts = CreateCategoryProductsJson(context);
            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();
        }

        private static List<CategoryProduct> CreateCategoryProductsJson(ProductsShopContext context)
        {
            var categoryProducts = new List<CategoryProduct>();
            var product = context.Products.ToList();
            var categories = context.Categories.ToList();
            var random = new Random();

            for (int i = 0; i < product.Count; i++)
            {
                var categoriesCount = random.Next(1, 4);
                var currentCategories = new HashSet<Category>();

                for (int j = 1; j <= categoriesCount; j++)
                {
                    var category = categories[random.Next(0, categories.Count)];
                    currentCategories.Add(category);
                }

                currentCategories.ToList()
                    .ForEach(c => categoryProducts.Add(new CategoryProduct { Category = c, Product = product[i] }));
            }

            return categoryProducts.ToList();
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
