using System.Collections.Generic;
using System.Linq;

namespace StackOfStrings
{
    public class StackOfStrings
    {
        private readonly List<string> data;

        public StackOfStrings()
        {
            this.data = new List<string>();
        }

        public void Push(string item)
        {
            this.data.Add(item);
        }

        public string Pop()
        {
            var element = this.data[this.data.Count - 1];
            this.data.RemoveAt(this.data.Count - 1);
            return element;
        }

        public string Peek()
        {
            return this.data[this.data.Count - 1];
        }

        public bool IsEmpty()
        {
            return this.data.Any();
        }
    }
}
