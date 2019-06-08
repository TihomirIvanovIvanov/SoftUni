namespace Mishmash.Models
{
    public class UserInChannel
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string ChannelId { get; set; }

        public virtual Channel Channel { get; set; }
    }
}
