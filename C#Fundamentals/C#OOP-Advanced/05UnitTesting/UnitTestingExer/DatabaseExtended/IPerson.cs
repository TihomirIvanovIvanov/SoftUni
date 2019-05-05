namespace DatabaseExtended
{
    public interface IPerson
    {
        long Id { get; }

        string Username { get; }

        bool Equals(IPerson other);
    }
}
