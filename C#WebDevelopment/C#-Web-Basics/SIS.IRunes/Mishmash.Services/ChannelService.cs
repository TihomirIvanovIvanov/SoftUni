namespace Mishmash.Services
{
    using Data;
    using Models;
    using System.Linq;

    public class ChannelService : IChannelService
    {
        private readonly MishmashDbContext context;

        public ChannelService(MishmashDbContext context)
        {
            this.context = context;
        }

        public Channel GetChannelById(string id)
        {
            return this.context.Channels.SingleOrDefault(ch => ch.Id == id);
        }
    }
}
