namespace Mishmash.App.ViewModels.Channels
{
    using Models;
    public class FollowedChannelViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ChannelType Type { get; set; }

        public int FollowersCount { get; set; }
    }
}
