namespace Mishmash.Services
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class ChannelService : IChannelService
    {
        private readonly MishmashDbContext context;

        public ChannelService(MishmashDbContext context)
        {
            this.context = context;
        }

        public Channel CreateChannel(Channel channel)
        {
            channel = this.context.Channels.Add(channel).Entity;
            this.context.SaveChanges();

            return channel;
        }

        public ICollection<Channel> GetAllChannels()
        {
            return this.context.Channels.ToList();
        }

        public Channel GetChannelById(string id)
        {
            // TODO: koe e vqrnoto v single-a da sravnqvam id ili za vs kolekciq
            return this.context.Channels
                .Include(channel => channel.Tags)/*.ThenInclude(tags => tags.ChannelId == id)*/
                .Include(channel => channel.Followers)/*.ThenInclude(followers => followers.ChannelId == id)*/
                .SingleOrDefault(channel => channel.Id == id);
        }

        public bool AddFollowersInChannel(string channelId, UserInChannel followersFromDb)
        {
            var channelFromDb = this.GetChannelById(channelId);

            if (channelFromDb == null)
            {
                return false;
            }

            channelFromDb.Followers.Add(followersFromDb);

            this.context.Update(channelFromDb);
            this.context.SaveChanges();

            return true;
        }

        public bool AddTagToChannel(string channelId, ChannelTag channelTag)
        {
            var channelFromDb = this.GetChannelById(channelId);

            if (channelFromDb == null)
            {
                return false;
            }

            channelFromDb.Tags.Add(channelTag);

            this.context.Update(channelFromDb);
            this.context.SaveChanges();

            return true;
        }
    }
}
