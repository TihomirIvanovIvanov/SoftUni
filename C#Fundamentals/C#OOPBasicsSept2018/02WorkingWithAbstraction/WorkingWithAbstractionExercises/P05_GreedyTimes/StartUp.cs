namespace P05_GreedyTimes
{
    using Items;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var bag = new Bag(capacity);

            for (int i = 0; i < input.Length; i += 2)
            {
                var key = input[i];
                var value = long.Parse(input[i + 1]);

                InsertItem(key, value, bag);
            }

            Console.WriteLine(bag.ToString().TrimEnd());
        }

        private static void InsertItem(string key, long value, Bag bag)
        {
            if (key.Length == 3)
            {
                var cash = new Cash(key, value);
                bag.AddCashItem(cash);
            }
            else if (key.Length >= 4 && key.ToLower().EndsWith("gem"))
            {
                var gem = new Gem(key, value);
                bag.AddGemItem(gem);
            }
            else if (key.ToLower().EndsWith("gold"))
            {
                var gold = new Gold(key, value);
                bag.AddGoldItem(gold);
            }
        }
    }
}