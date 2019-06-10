namespace Mishmash.App.ViewModels.Home
{
    using Channels;
    using System.Collections.Generic;

    public class LoggedInIndexViewModel
    {
        public string UserRole { get; set; }

        public IEnumerable<FollowedChannelViewModel> YourChannel { get; set; }

        public IEnumerable<FollowedChannelViewModel> SuggestedChannels { get; set; }

        public IEnumerable<FollowedChannelViewModel> SeeOtherChannels { get; set; }
    }
}
