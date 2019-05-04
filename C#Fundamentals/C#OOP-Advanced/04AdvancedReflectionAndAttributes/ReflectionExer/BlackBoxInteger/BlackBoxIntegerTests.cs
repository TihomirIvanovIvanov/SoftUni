namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var classType = typeof(BlackBoxInteger);
            var instance = (BlackBoxInteger)Activator.CreateInstance(classType, true);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var commandArgs = command.Split('_', StringSplitOptions.RemoveEmptyEntries);
                var methodName = commandArgs[0];
                var value = int.Parse(commandArgs[1]);

                classType.GetMethod(methodName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Invoke(instance, new object[] { value });

                var currentValue = (int)classType.GetField("innerValue",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .GetValue(instance);

                Console.WriteLine(currentValue);
            }
        }
    }
}
