namespace Database.Contracts
{
    public interface IDatabase
    {
        void Add(int element);

        void Remove();

        int[] Fetch();
    }
}