using P05_GreedyTimes.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class StartUp
    {
        public static void Main()
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Bag(capacity);

            for (int i = 0; i < input.Length; i += 2)
            {
                string key = input[i];
                long value = long.Parse(input[i + 1]);

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