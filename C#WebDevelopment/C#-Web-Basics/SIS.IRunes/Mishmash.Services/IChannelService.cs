namespace Mishmash.Services
{
    using Models;
    using System.Collections.Generic;

    public interface IChannelService
    {
        Channel CreateChannel(Channel channel);

        bool AddTagToChannel(string channelId, ChannelTag channelTag);

        bool AddFollowersInChannel(string channelId, UserInChannel followersInChannel);

        ICollection<Channel> GetAllChannels();

        Channel GetChannelById(string id);
    }
}
