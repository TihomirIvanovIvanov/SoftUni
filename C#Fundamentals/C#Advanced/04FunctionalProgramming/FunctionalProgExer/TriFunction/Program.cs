using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> isCorrectName = (name, checkLength) =>
            {
                var sum = 0;
                foreach (var character in name)
                {
                    sum += character;
                }

                return sum >= checkLength;
            };

            Func<Func<string, int, bool>, string, int, string> getName = (conditionFunc, nameAsString, checkLength) =>
            {
                return nameAsString.Split(' ')
                    .FirstOrDefault(name => conditionFunc(name, checkLength));
            };

            var lenghth = int.Parse(Console.ReadLine());
            Console.WriteLine(getName(isCorrectName, Console.ReadLine(), lenghth));
        }
    }
}
