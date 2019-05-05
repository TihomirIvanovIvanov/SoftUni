namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Database : IDatabase
    {
        private const int MaxCapacity = 16;

        private readonly int[] data;
        private int currentIndex;

        public Database()
        {
            this.data = new int[MaxCapacity];
            this.currentIndex = 0;
        }

        public Database(params int[] inputElements)
            : this()
        {
            this.InitializeElements(inputElements);
        }

        public void Add(int element)
        {
            if (this.currentIndex >= MaxCapacity)
            {
                throw new InvalidOperationException("Array is full");
            }

            this.data[this.currentIndex] = element;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Array is empty");
            }

            this.currentIndex--;
            this.data[this.currentIndex] = default(int);
        }

        public int[] Fetch()
        {
            var newArray = new int[this.currentIndex];
            Array.Copy(this.data, newArray, this.currentIndex);

            return newArray;
        }

        private void InitializeElements(int[] inputElements)
        {
            try
            {
                Array.Copy(inputElements, this.data, inputElements.Length);
                this.currentIndex = inputElements.Length;
            }
            catch (ArgumentException ioe)
            {
                throw new InvalidOperationException("Array is full", ioe);
            }
        }
    }
}
