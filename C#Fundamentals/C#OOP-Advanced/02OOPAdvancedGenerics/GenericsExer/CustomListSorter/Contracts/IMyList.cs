namespace CustomListSorter.Contracts
{
    public interface IMyList<T>
    {
        int Count { get; }

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