using System;
using System.Linq;

public class Engine : IEngine
{
    private const string ShutdownCommand = "Shutdown";

    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter commandInterpreter;

    public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            try
            {
                //TODO
                var input = this.reader.ReadLine().Trim();
                var data = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var result = this.commandInterpreter.ProcessCommand(data).Trim();

                this.writer.WriteLine(result);

                if (input == ShutdownCommand)
                {
                    break;
                }
            }
            catch (Exception e)
            {
                this.writer.WriteLine(e.Message);
            }
        }
    }
}
