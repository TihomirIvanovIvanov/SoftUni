namespace CustomListSorter.Models
{
    using Contracts;
    using System;

    public class CommandInterpreter
    {
        private IMyList<string> myList;

        public CommandInterpreter()
        {
            this.myList = new MyList<string>();
        }

        public void TryExecuteCommand(string input)
        {
            var commandArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var command = commandArgs[0];

            switch (command)
            {
                case "Add":
                    this.myList.Add(commandArgs[1]);
                    break;
                case "Remove":
                    this.myList.Remove(int.Parse(commandArgs[1]));
                    break;
                case "Contains":
                    Console.WriteLine(this.myList.Contains(commandArgs[1]));
                    break;
                case "Swap":
                    this.myList.Swap(int.Parse(commandArgs[1]), int.Parse(commandArgs[2]));
                    break;
                case "Greater":
                    Console.WriteLine(this.myList.CountGreaterThan(commandArgs[1]));
                    break;
                case "Max":
                    Console.WriteLine(this.myList.Max());
                    break;
                case "Min":
                    Console.WriteLine(this.myList.Min());
                    break;
                case "Sort":
                    this.myList.Sort();
                    break;
                case "Print":
                    Console.WriteLine(this.myList.ToString());
                    break;
            }
        }
    }
}