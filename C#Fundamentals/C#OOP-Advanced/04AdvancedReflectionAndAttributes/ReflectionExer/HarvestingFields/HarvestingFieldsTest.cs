namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var classType = typeof(HarvestingFields);

            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                IEnumerable<FieldInfo> fieldInfos = null;

                switch (command)
                {
                    case "private":
                        fieldInfos = GetPrivateFields(classType);
                        break;

                    case "protected":
                        fieldInfos = GetProtectedFields(classType);
                        break;

                    case "public":
                        fieldInfos = GetPublicFields(classType);
                        break;

                    case "all":
                        fieldInfos = GetAllFields(classType);
                        break;

                }

                foreach (var field in fieldInfos)
                {
                    var accessModifier = field.IsPublic ? "public" : field.IsPrivate ? "private" : "protected";
                    Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
                }
            }
        }

        private static IEnumerable<FieldInfo> GetAllFields(Type classType)
        {
                                    //(BindingFlags)62
            return classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }

        private static IEnumerable<FieldInfo> GetPublicFields(Type classType)
        {
            return classType.GetFields(BindingFlags.Instance | BindingFlags.Public)
                .Where(f => f.IsPublic);
        }

        private static IEnumerable<FieldInfo> GetProtectedFields(Type classType)
        {
            return classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsFamily);
        }

        private static IEnumerable<FieldInfo> GetPrivateFields(Type classType)
        {
            return classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate);
        }
    }
}