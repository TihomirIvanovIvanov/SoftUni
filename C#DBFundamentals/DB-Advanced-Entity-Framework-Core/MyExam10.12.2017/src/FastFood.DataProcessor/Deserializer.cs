using FastFood.Data;
using System;

namespace FastFood.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            throw new Exception();
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            throw new Exception();
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            throw new Exception();
        }
    }
}