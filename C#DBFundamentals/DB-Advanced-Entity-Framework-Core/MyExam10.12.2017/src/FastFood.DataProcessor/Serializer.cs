using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using FastFood.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

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

            return JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            var categoriesAsArray = categoriesString.Split(',').ToArray();

            var cagetories = context.Categories
                .Where(c => categoriesAsArray.Contains(c.Name))
                .Select(c => new
                {
                    c.Name,
                    Items = c.Items.ToList()
                })
                .ToList()
                .Select(c => new
                {
                    c.Name,
                    MostPopularItem = c.Items
                    .Select(i => new
                    {
                        i.Name,
                        TotalMade = i.Price * i.OrderItems.Sum(oi => oi.Quantity),
                        TimesSold = i.OrderItems.Sum(oi => oi.Quantity)
                    })
                    .ToList()
                    .OrderByDescending(i => i.TotalMade)
                    .ThenByDescending(i => i.TimesSold)
                    .FirstOrDefault()
                })
                .Select(c => new CategoryDtoXml
                {
                    Name = c.Name,
                    MostPopularItem = new MostPopularItemDtoXml
                    {
                        Name = c.MostPopularItem.Name,
                        TotalMade = c.MostPopularItem.TotalMade,
                        TimesSold = c.MostPopularItem.TimesSold
                    }
                })
                .OrderByDescending(c => c.MostPopularItem.TotalMade)
                .ThenByDescending(c => c.MostPopularItem.TimesSold)
                .ToList();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(CategoryDtoXml[]), new XmlRootAttribute("Categories"));
            serializer.Serialize
                (new StringWriter(sb), cagetories, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            var result = sb.ToString();
            return result;
        }
    }
}