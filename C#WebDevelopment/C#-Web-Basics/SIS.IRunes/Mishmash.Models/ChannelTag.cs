namespace Mishmash.Models
{
    public class ChannelTag
    {
        public string Id { get; set; }

        public string ChannelId { get; set; }

        public virtual Channel Channel { get; set; }

        public string TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
