namespace Database.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database : IDatabase
    {
        private readonly int defaultCapacity;
        private int currentElement;
        private readonly IList<int> data;
        private readonly int[] elements;

        public Database(params int[] elements)
        {
            this.defaultCapacity = 16;
            this.elements = elements;
            this.data = new int[this.defaultCapacity];
            this.currentElement = 0;
            this.SetData();
        }

        public int Count
        {
            get => this.currentElement;
            set => this.currentElement = value;
        }

        private void SetData()
        {
            if (this.elements == null)
            {
                throw new InvalidOperationException();
            }

            if (this.elements.Length > this.defaultCapacity)
            {
                throw new InvalidOperationException();
            }

            for (int i = 0; i < this.elements.Length; i++)
            {
                this.data[i] = this.elements[i];
                this.Count++;
            }
        }

        public void Add(int element)
        {
            if (this.currentElement == this.defaultCapacity)
            {
                throw new InvalidOperationException();
            }

            this.data[this.currentElement] = element;
            this.currentElement++;
        }

        public void Remove()
        {
            if (this.currentElement == 0)
            {
                throw new InvalidOperationException();
            }

            this.data[this.currentElement] = default(int);
            this.currentElement--;
        }

        public int[] Fetch()
        {
            var temp = new int[this.Count];
            Array.Copy(this.data.ToArray(), 0, temp, 0, this.Count);

            return temp;
        }
    }
}
