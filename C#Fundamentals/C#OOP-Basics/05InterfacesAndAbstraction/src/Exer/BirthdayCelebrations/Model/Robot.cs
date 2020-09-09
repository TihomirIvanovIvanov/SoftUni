using BirthdayCelebrations.Contracts;

namespace BirthdayCelebrations.Model
{
    public class Robot : IIdentifiable
    {
        private readonly string model;

        public Robot(string model, string id)
        {
            this.model = model;
            this.Id = id;
        }

        public string Id { get; }
    }
}
