namespace CustomList
{
    using Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            CommandInterpreter engine = new CommandInterpreter();
            var command = Console.ReadLine();

            while (!command.Equals("END"))
            {
                engine.TryExecuteCommand(command);
                command = Console.ReadLine();
            }
        }
    }
}