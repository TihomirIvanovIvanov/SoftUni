namespace GenericSwapMethodInteger
{
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        public Box(List<T> items)
        {
            Items = items;
        }

        public List<T> Items { get; }

        public void Swap(int index1, int index2)
        {
            T temp = this.Items[index1];
            this.Items[index1] = this.Items[index2];
            this.Items[index2] = temp;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this.Items)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}