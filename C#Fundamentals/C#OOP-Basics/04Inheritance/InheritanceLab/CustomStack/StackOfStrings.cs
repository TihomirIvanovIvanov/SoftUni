using System.Collections.Generic;
using System.Linq;

namespace CustomStack
{
    public class StackOfStrings
    {
        private List<string> data;

        public StackOfStrings()
        {
            this.Data = new List<string>();
        }

        public List<string> Data { get => data; set => data = value; }

        public void Push(string item)
        {
            this.Data.Add(item);
        }

        public string Pop()
        {
            var element = this.Data[this.Data.Count - 1];
            this.Data.RemoveAt(this.Data.Count - 1);
            return element;
        }

        public string Peek()
        {
            return this.Data[this.Data.Count - 1];
        }

        public bool IsEmpty()
        {
            return this.Data.Any();
        }
    }
}