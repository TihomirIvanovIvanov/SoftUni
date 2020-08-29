using System;

namespace StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            var studentSystem = new StudentSystem();

            while (true)
            {
                var command = Console.ReadLine();
                studentSystem.ParseCommand(command);
            }
        }
    }
}
