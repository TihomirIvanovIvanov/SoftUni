namespace SoftUniDependencyInjection.Models
{
    using Contracts;
    using System.IO;

    public class FileWriter : IWriter
    {
        private const string Path = "log.txt";

        public void WriteLine(string content)
        {
            File.AppendAllText(Path, content);
        }
    }
}
