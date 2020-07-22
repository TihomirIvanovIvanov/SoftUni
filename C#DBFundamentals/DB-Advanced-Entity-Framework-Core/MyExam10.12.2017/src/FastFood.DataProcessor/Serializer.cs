using FastFood.Data;
using FastFood.Models;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace FastFood.DataProcessor
{
    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var type = Enum.Parse<OrderType>(orderType);

            var ordersByEmployee = context.Orders
                .Where(o => o.Employee.Name == employeeName && o.Type == type)
                .Select(o => new
                {
                    o.Customer,
                    Items = o.OrderItems
                        .Select(oi => new
                        {
                            oi.Item.Name,
                            oi.Item.Price,
                            oi.Quantity
                        })
                        .ToList()
                    ,
                    TotalPrice = o.OrderItems.Sum(oi => oi.Quantity * oi.Item.Price),
                })
                .OrderByDescending(o => o.TotalPrice)
                .ThenByDescending(o => o.Items.Count)
                .ToList();

            var result = new
            {
                Name = employeeName,
                Orders = ordersByEmployee,
                TotalMade = ordersByEmployee.Sum(o => o.TotalPrice)
            };

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            throw new Exception();
        }
    }
}