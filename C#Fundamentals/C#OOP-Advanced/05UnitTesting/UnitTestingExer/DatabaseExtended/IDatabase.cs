namespace DatabaseExtended
{
    public interface IDatabase<IPerson>
    {
        int CurrentIndex { get; }

        void AddPerson(IPerson element);

        void Remove();

        IPerson FindByUsername(string name);

        IPerson FindById(long id);
    }
}