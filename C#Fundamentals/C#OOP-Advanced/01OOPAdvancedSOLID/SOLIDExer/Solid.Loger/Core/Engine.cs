namespace Solid.Loger.Core
{
    using Contracts;
    using System;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            var numberOfAppenders = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfAppenders; i++)
            {
                var inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                this.commandInterpreter.AddAppender(inputArgs);
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var inputArgs = input.Split('|', StringSplitOptions.RemoveEmptyEntries);

                this.commandInterpreter.AddMessage(inputArgs);
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
