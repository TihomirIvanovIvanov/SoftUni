namespace SoftUniDependencyInjection.Core
{
    using Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IWriter fileWriter;
        private readonly IReader reader;

        public Engine(IWriter fileWriter, IReader reader)
        {
            this.fileWriter = fileWriter;
            this.reader = reader;
        }

        public void Run()
        {
            var content = this.reader.ReadLine();
            this.fileWriter.WriteLine(content);
        }
    }
}
