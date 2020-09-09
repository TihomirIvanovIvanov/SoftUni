using System;

namespace Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split();
            var urls = Console.ReadLine().Split();

            var smartphone = new Smartphone();

            foreach (var num in numbers)
            {
                Console.WriteLine(smartphone.Call(num));
            }

            foreach (var url in urls)
            {
                Console.WriteLine(smartphone.Browse(url));
            }
        }
    }
}
