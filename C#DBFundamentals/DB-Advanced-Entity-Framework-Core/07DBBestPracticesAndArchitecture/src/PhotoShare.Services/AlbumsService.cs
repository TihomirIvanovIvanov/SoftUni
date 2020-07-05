using PhotoShare.Data;
using PhotoShare.Models;
using System;
using System.Linq;

namespace PhotoShare.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly PhotoShareContext context;

        private readonly IUsersService usersService;

        private readonly IUsersSessionService usersSessionService;

        public AlbumsService(PhotoShareContext context, IUsersService usersService, IUsersSessionService usersSessionService)
        {
            this.context = context;
            this.usersService = usersService;
            this.usersSessionService = usersSessionService;
        }

        public Tag CreateTag(string name)
        {
            var tag = context.Tags.FirstOrDefault(t => t.Name == name);

            if (tag != null)
            {
                throw new ArgumentException($"Tag {tag.Name} exists!");
            }

            tag = new Tag { Name = name };

            this.context.Tags.Add(tag);
            this.context.SaveChanges();

            return tag;
        }
    }
}
