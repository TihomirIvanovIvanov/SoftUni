namespace BorderControl
{
    public class Citizen : IIdentifiable
    {
        private readonly string name;

        private readonly int age;

        public Citizen(string name, int age, string id)
        {
            this.name = name;
            this.age = age;
            this.Id = id;
        }

        public string Id { get; }
    }
}
