namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        public Box(T item)
        {
            this.Item = item;
        }

        public T Item { get; }

        public override string ToString()
        {
            return $"{this.Item.GetType().FullName}: {this.Item}";
        }
    }
}