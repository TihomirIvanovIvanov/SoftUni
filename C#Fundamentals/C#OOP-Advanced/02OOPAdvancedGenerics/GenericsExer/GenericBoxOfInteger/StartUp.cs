namespace GenericBoxOfInteger
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var item = int.Parse(Console.ReadLine());
                var box = new Box<int>(item);
                Console.WriteLine(box);
            }
        }
    }
}