namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var all = new List<IIdentifiable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs.Length == 3)
                {
                    var citizenName = inputArgs[0];
                    var citizenAge = int.Parse(inputArgs[1]);
                    var citizenId = inputArgs[2];

                    var citizen = new Citizen(citizenName, citizenAge, citizenId);
                    all.Add(citizen);
                }
                else if (inputArgs.Length == 2)
                {
                    var robotModel = inputArgs[0];
                    var robotId = inputArgs[1];

                    var robot = new Robot(robotModel, robotId);
                    all.Add(robot);
                }
            }

            var lastDigits = Console.ReadLine();

            all.Where(c => c.Id.EndsWith(lastDigits))
                .Select(c => c.Id)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}