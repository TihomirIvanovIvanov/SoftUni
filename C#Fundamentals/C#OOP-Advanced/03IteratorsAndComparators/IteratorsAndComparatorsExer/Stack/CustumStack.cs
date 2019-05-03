namespace Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustumStack<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int currentIndex = -1;

        public CustumStack()
        {
            this.elements = new List<T>();
        }

        public void Push(params T[] items)
        {
            foreach (var item in items)
            {
                elements.Insert(++this.currentIndex, item);
            }
        }

        public void Pop()
        {
            if (this.currentIndex < 0)
            {
                throw new InvalidOperationException("No elements");
            }

            this.currentIndex--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.currentIndex; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
