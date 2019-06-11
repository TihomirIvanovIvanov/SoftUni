namespace Mishmash.Services
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class TagService : ITagService
    {
        private readonly MishmashDbContext context;

        public TagService(MishmashDbContext context)
        {
            this.context = context;
        }

        public Tag CreateTag(Tag tag)
        {
            tag = this.context.Tags.Add(tag).Entity;
            this.context.SaveChanges();

            return tag;
        }

        public ICollection<Tag> GetAllTags()
        {
            return this.context.Tags.ToList();
        }

        public Tag GetTagById(string id)
        {
            return this.context.Tags
                .Include(tag => tag.Channels)
                .SingleOrDefault(tag => tag.Id == id);
        }

        public bool AddTagToChannel(string tagId, ChannelTag channelTag)
        {
            var tagFromDb = this.GetTagById(tagId);

            if (tagFromDb == null)
            {
                return false;
            }

            tagFromDb.Channels.Add(channelTag);

            this.context.Update(tagFromDb);
            this.context.SaveChanges();

            return true;
        }
    }
}