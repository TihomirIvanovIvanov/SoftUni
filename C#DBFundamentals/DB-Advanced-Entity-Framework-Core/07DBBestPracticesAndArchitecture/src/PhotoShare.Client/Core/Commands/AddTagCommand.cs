namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Data;
    using Utilities;

    public class AddTagCommand : ICommand
    {
        // AddTag <tag>
        public string Execute(string command, string[] data)
        {
            string tag = data[1].ValidateOrTransform();

            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Tags.Add(new Tag
                {
                    Name = tag
                });

                context.SaveChanges();
            }

            return tag + " was added successfully to database!";
        }
    }
}
