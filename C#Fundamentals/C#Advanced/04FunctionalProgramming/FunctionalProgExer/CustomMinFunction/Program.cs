using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> custum = numArray =>
            {
                var min = int.MaxValue;
                for (int i = 0; i < numArray.Length; i++)
                {
                    if (min > numArray[i])
                    {
                        min = numArray[i];
                    }
                }

                return min;
            };
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(custum(input));
        }
    }
}
