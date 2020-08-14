using System;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = inputString =>
            {
                var collection = inputString
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(string.Join(Environment.NewLine, collection));
            };
            print(Console.ReadLine());
        }
    }
}
