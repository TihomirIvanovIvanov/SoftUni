namespace P03_StudentSystem
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            StudentSystem system = new StudentSystem();

            while (true)
            {
                string command = Console.ReadLine();
                system.ParseCommand(command);
            }
        }
    }
}