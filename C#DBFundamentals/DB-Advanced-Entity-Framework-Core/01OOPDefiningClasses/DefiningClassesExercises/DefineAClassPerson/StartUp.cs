using System;
using System.Reflection;

namespace DefineAClassPerson
{
    public class StartUp
    {
        public static void Main()
        {
            Type personType = typeof(Person);
            PropertyInfo[] properties = personType.GetProperties
                (BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(properties.Length);

            Person pesho = new Person();
            pesho.Name = "Pesho";
            pesho.Age = 20;

            Person gosho = new Person();
            gosho.Name = "Gosho";
            gosho.Age = 18;

            Person stamat = new Person();
            stamat.Name = "Stamat";
            stamat.Age = 43;
        }
    }
}
