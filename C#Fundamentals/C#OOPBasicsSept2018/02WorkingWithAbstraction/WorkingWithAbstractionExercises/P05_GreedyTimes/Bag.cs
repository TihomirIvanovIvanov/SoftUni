namespace P05_GreedyTimes
{
    using Items;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
            get
            {
                return this.bag
                    .Where(g => g is Gold)
                    .Sum(g => g.Value);
            }
        }

        public long CashItemsValue
        {
            get
            {
                return this.bag
                    .Where(c => c is Cash)
                    .Sum(c => c.Value);
            }
        }

        public long GemItemsValue
        {
            get
            {
                return this.bag
                    .Where(g => g is Gem)
                    .Sum(g => g.Value);
            }
        }

        public void AddGoldItem(Gold item)
        {
            if (this.capacity >= this.current + item.Value)
            {
                var goldItems = GetGoldItems();

                if (goldItems.Any(g => g.Key == item.Key))
                {
                    goldItems.Single(g => g.Key == item.Key).IncreaseValue(item.Value);
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

                if (gemItems.Any(g => g.Key == item.Key))
                {
                    gemItems.Single(g => g.Key == item.Key).IncreaseValue(item.Value);
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

                if (cashItems.Any(c => c.Key == item.Key))
                {
                    cashItems.Single(c => c.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    this.bag.Add(item);
                }

                this.current += item.Value;
            }
        }

        private List<Item> GetCashItems()
        {
            return this.bag
                .Where(c => c is Cash)
                .ToList();
        }

        private List<Item> GetGemItems()
        {
            return this.bag
                 .Where(g => g is Gem)
                 .ToList();
        }

        private List<Item> GetGoldItems()
        {
            return this.bag
                .Where(g => g is Gold)
                .ToList();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var dictionary = this.bag
                .GroupBy(b => b.GetType().Name)
                .ToDictionary(b => b.Key, b => b.ToList())
                .OrderByDescending(kv => kv.Value.Sum(i => i.Value));

            foreach (var kvp in dictionary)
            {
                if (kvp.Key == "Cash")
                {
                    sb.AppendLine($"<Cash> ${kvp.Value.Sum(i => i.Value)}");
                }
                else if (kvp.Key == "Gem")
                {
                    sb.AppendLine($"<Gem> ${kvp.Value.Sum(i => i.Value)}");
                }
                else if (kvp.Key == "Gold")
                {
                    sb.AppendLine($"<Gold> ${kvp.Value.Sum(i => i.Value)}");
                }

                foreach (var item in kvp.Value.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
                {
                    sb.AppendLine($"##{item.Key} - {item.Value}");
                }
            }

            return sb.ToString();
        }
    }
}