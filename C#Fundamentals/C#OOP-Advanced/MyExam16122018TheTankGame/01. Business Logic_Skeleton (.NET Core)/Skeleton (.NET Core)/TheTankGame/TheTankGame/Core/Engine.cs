namespace TheTankGame.Core
{
    using Contracts;
    using IO.Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader,
            IWriter writer,
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine().Split();
                try
                {
                    var result = this.commandInterpreter.ProcessInput(input);
                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
                if (input[0] == "Terminate")
                {
                    break;
                }
            }
        }
    }
}