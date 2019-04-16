namespace FirstAndReserveTeam
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Team teams = new Team("United");
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                try
                {
                    string[] inputArgs = Console.ReadLine().Split();

                    string firstName = inputArgs[0];
                    string lastName = inputArgs[1];
                    int age = int.Parse(inputArgs[2]);
                    double salary = double.Parse(inputArgs[3]);

                    Person players = new Person(firstName, lastName, age, salary);

                    teams.AddPlayer(players);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine($"First team have {teams.FirstTeam.Count} players");
            Console.WriteLine($"Second team have {teams.ReserveTeam.Count} players");
        }
    }
}
