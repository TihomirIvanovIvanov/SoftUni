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

            context.SaveChanges();
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
