namespace RhombusOfStars
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var stars = int.Parse(Console.ReadLine());

            for (int i = 1; i <= stars; i++)
            {
                PrintRow(stars, i);
            }

            for (int i = stars - 1; i > 0; i--)
            {
                PrintRow(stars, i);
            }
        }

        private static void PrintRow(int rhombusSize, int rowSize)
        {
            for (int i = 0; i < rhombusSize - rowSize; i++)
            {
                Console.Write(' ');
            }

            for (int i = 0; i < rowSize; i++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }
}