namespace Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            CustumStack<int> custumStack = new CustumStack<int>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (args[0])
                {
                    case "Push":
                        var elements = args.Skip(1)
                            .Select(e => e.Split(',').First())
                            .Select(int.Parse)
                            .ToArray();

                        custumStack.Push(elements);
                        break;
                    case "Pop":
                        try
                        {
                            custumStack.Pop();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                }
            }

            foreach (var item in custumStack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in custumStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}