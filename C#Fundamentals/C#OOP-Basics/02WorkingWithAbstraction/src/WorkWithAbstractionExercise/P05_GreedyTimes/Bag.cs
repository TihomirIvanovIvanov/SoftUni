using P05_GreedyTimes.Items;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Bag
    {
        private List<Item> bag;

        private long capacity;

        private long current;

        public Bag(long capacity)
        {
            this.capacity = capacity;
            this.bag = new List<Item>();
        }

        public long GoldItemsValue
        {
            get => this.bag.Where(gold => gold is Gold).Sum(gold => gold.Value);
        }

        public long GemItemsValue
        {
            get => this.bag.Where(gem => gem is Gem).Sum(gem => gem.Value);
        }

        public long CashItemsValue
        {
            get => this.bag.Where(cash => cash is Cash).Sum(cash => cash.Value);
        }

        public void AddGoldItem(Gold item)
        {
            if (this.capacity >= this.current + item.Value)
            {
                var goldItems = GetGoldItems();

                if (goldItems.Any(gold => gold.Key == item.Key))
                {
                    goldItems.Single(gold => gold.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    this.bag.Add(item);
                }

                this.current += item.Value;
            }
        }

        public void AddGemItem(Gem item)
        {
            if (this.capacity >= this.current + item.Value &&
                GoldItemsValue >= GemItemsValue + item.Value)
            {
                var gemItems = GetGemItems();

                if (gemItems.Any(gem => gem.Key == item.Key))
                {
                    gemItems.Single(gem => gem.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    this.bag.Add(item);
                }

                this.current += item.Value;
            }
        }

        public void AddCashItem(Cash item)
        {
            if (this.capacity >= this.current + item.Value &&
                GemItemsValue >= CashItemsValue + item.Value)
            {
                var cashItems = GetCashItems();

                if (cashItems.Any(cash => cash.Key == item.Key))
                {
                    cashItems.Single(cash => cash.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    this.bag.Add(item);
                }

                this.current += item.Value;
            }
        }

        private List<Item> GetGoldItems()
        {
            return this.bag.Where(gold => gold is Gold).ToList();
        }

        private List<Item> GetGemItems()
        {
            return this.bag.Where(gem => gem is Gem).ToList();
        }

        private List<Item> GetCashItems()
        {
            return this.bag.Where(cash => cash is Cash).ToList();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var dictionary = this.bag
                .GroupBy(bag => bag.GetType().Name)
                .ToDictionary(bag => bag.Key, bag => bag.ToList())
                .OrderByDescending(bag => bag.Value.Sum(item => item.Value));

            foreach (var kvp in dictionary)
            {
                if (kvp.Key == "Cash")
                {
                    sb.AppendLine($"<Cash> ${kvp.Value.Sum(item => item.Value)}");
                }
                if (kvp.Key == "Gem")
                {
                    sb.AppendLine($"<Gem> ${kvp.Value.Sum(item => item.Value)}");
                }
                if (kvp.Key == "Gold")
                {
                    sb.AppendLine($"<Gold> ${kvp.Value.Sum(item => item.Value)}");
                }

                foreach (var item in kvp.Value.OrderByDescending(item => item.Key).ThenBy(item => item.Value))
                {
                    sb.AppendLine($"##{item.Key} - {item.Value}");
                }
            }

            return sb.ToString();
        }
    }
}