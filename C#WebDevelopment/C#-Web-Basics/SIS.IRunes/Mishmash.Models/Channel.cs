﻿namespace Mishmash.Models
{
    using System.Collections.Generic;

    public class Channel
    {
        public Channel()
        {
            this.Followers = new HashSet<UserInChannel>();
            this.Tags = new HashSet<ChannelTag>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ChannelType Type { get; set; }

        public virtual ICollection<ChannelTag> Tags { get; set; }

        public virtual ICollection<UserInChannel> Followers { get; set; }
    }
}
