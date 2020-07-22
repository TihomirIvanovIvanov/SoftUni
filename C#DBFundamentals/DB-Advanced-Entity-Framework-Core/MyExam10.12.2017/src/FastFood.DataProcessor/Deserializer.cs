using FastFood.Data;
using FastFood.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var result = new List<string>();

            var objects = JsonConvert.DeserializeAnonymousType
                (jsonString, new[] { new { Name = string.Empty, Age = 0, Position = string.Empty } });

            foreach (var obj in objects)
            {
                if (obj.Name == null || obj.Position == null || obj.Name.Length < 3 || obj.Name.Length > 30 ||
                    obj.Age < 15 || obj.Age > 80 || obj.Position.Length < 3 || obj.Position.Length > 30)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var positionExists = context.Positions.Any(p => p.Name == obj.Position);
                if (!positionExists)
                {
                    context.Positions.Add(new Position { Name = obj.Position });
                    context.SaveChanges();
                }

                var position = context.Positions.FirstOrDefault(p => p.Name == obj.Position);

                var employee = new Employee
                {
                    Name = obj.Name,
                    Age = obj.Age,
                    Position = position
                };
                context.Employees.Add(employee);
                context.SaveChanges();

                result.Add(string.Format(SuccessMessage, obj.Name));
            }

            return string.Join(Environment.NewLine, result);
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var result = new List<string>();

            var objects = JsonConvert.DeserializeAnonymousType(
                jsonString, new[] { new { Name = string.Empty, Price = 0.00m, Category = string.Empty } });

            foreach (var obj in objects)
            {
                var itemExists = context.Items.Any(i => i.Name == obj.Name);

                if (itemExists || obj.Name.Length < 3 || obj.Name.Length > 30 ||
                    obj.Price < 0.01m ||
                    obj.Category.Length < 3 || obj.Category.Length > 30)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var categoryExists = context.Items.Any(i => i.Name == obj.Category);

                if (!categoryExists)
                {
                    var category = new Category { Name = obj.Category };
                    context.Categories.Add(category);
                    context.SaveChanges();
                }

                var categoryFromDb = context.Categories.FirstOrDefault(c => c.Name == obj.Category);

                var item = new Item
                {
                    Category = categoryFromDb,
                    Name = obj.Name,
                    Price = obj.Price,
                };
                context.Items.Add(item);
                context.SaveChanges();

                result.Add(string.Format(SuccessMessage, obj.Name));
            }

            return string.Join(Environment.NewLine, result);
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            throw new Exception();
        }
    }
}