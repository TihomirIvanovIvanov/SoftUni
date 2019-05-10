namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            IList<string> args = inputParameters.Skip(1).ToList();

            string result = string.Empty;

            //if (command == "Vehicle")
            //{
            //    command = "Add" + command;
            //}
            //if (command == "Part")
            //{
            //    command = "Add" + command;
            //}

            //MethodInfo method = typeof(TankManager)
            // .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            // .FirstOrDefault(x => x.Name == command);

            var method = this.tankManager
                .GetType()
                .GetMethods()
                .FirstOrDefault(m => m.Name.Contains(command));

            result = (string)method.Invoke(this.tankManager, new object[] { args });
            return result;
        }
    }
}