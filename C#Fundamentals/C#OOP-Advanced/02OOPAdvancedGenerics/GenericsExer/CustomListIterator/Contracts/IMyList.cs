using System.Collections.Generic;

namespace CustomListIterator.Contracts
{
    public interface IMyList<T> : IEnumerable<T>
    {
        int Count { get; }

        T this[int number] { get; set; }

        void Add(T element);

        T Remove(int index);

        bool Contains(T element);

        void Swap(int index1, int index2);

        int CountGreaterThan(T element);

        T Max();

        T Min();

        void Sort();
    }
}