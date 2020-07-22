using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

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
            var result = new List<string>();

            var xDoc = XDocument.Parse(xmlString);

            var elements = xDoc.Root.Elements();

            foreach (var o in elements)
            {
                var customer = o.Element("Customer")?.Value;
                var employeeName = o.Element("Employee")?.Value;
                var timeAsString = o.Element("DateTime")?.Value;
                var typeAsString = o.Element("Type")?.Value;

                if (customer == null || employeeName == null || timeAsString == null || typeAsString == null)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var employee = context.Employees.FirstOrDefault(e => e.Name == employeeName);
                if (employee == null)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var dateTime = DateTime.ParseExact(timeAsString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var isTypeValid = Enum.TryParse<OrderType>(typeAsString, out var validType);
                if (!isTypeValid)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var type = validType;

                var areItemsValid = true;
                var items = new List<ItemDto>();

                foreach (var item in o.Element("Items").Elements())
                {
                    var name = item.Element("Name")?.Value;
                    var quantityAsString = item.Element("Quantity")?.Value;

                    if (quantityAsString == null || name == null)
                    {
                        result.Add(FailureMessage);
                        areItemsValid = false;
                    }

                    var quantity = int.Parse(quantityAsString);
                    var itemFromDb = context.Items.FirstOrDefault(i => i.Name == name);

                    if (itemFromDb == null || quantity <= 0)
                    {
                        result.Add(FailureMessage);
                        areItemsValid = false;
                    }

                    var itemDto = new ItemDto { Name = name, Quantity = quantity };
                    items.Add(itemDto);
                }

                if (!areItemsValid)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var order = new Order
                {
                    Customer = customer,
                    DateTime = dateTime,
                    Employee = employee,
                    Type = type,
                };

                context.Orders.Add(order);

                foreach (var itemDto in items)
                {
                    var item = context.Items.FirstOrDefault(i => i.Name == itemDto.Name);
                    var orderItems = new OrderItem
                    {
                        Item = item,
                        Order = order,
                        Quantity = itemDto.Quantity,
                    };

                    context.OrderItems.Add(orderItems);
                }

                context.SaveChanges();

                result.Add(
                    $"Order for {customer} on {dateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} added");
            }

            return string.Join(Environment.NewLine, result);
        }
    }
}