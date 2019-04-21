using System;
using System.Linq;

namespace Employee.App
{
    internal class Engine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        internal void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                string[] commandTokens = input.Split(' ');

                string commandName = commandTokens[0];

                string[] commandArgs = commandTokens.Skip(1).ToArray();
            }
        }
    }
}
