namespace P05_GreedyTimes.Items
{
    public class Item
    {
        public string Key { get; set; }

        public long Value { get; set; }

        public void IncreaseValue(long value)
        {
            this.Value += value;
        }
    }
}