namespace Mishmash.App.ViewModels.Channels
{
    using Models;
    using System.Collections.Generic;

    public class ChannelViewModel
    {
        public ChannelViewModel()
        {

        }

        public string Name { get; set; }

        public ChannelType Type { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public string TagsAsString => string.Join(", ", this.Tags);

        public int FollowersCount { get; set; }
    }
}
