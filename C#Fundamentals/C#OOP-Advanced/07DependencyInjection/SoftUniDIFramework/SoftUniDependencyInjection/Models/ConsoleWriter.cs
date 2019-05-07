namespace SoftUniDependencyInjection.Models
{
    using Contracts;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string content)
        {
            Console.WriteLine(content);
        }
    }
}
