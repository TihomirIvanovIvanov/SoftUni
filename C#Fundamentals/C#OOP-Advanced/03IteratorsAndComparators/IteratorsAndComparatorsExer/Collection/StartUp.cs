namespace Collection
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            ListyIterator<string> listyIterator = null;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (args[0])
                {
                    case "Create":
                        listyIterator = new ListyIterator<string>(args.Skip(1).ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext);
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                    case "PrintAll":
                        foreach (var elements in listyIterator)
                        {
                            Console.Write(elements + ' ');
                        }
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}