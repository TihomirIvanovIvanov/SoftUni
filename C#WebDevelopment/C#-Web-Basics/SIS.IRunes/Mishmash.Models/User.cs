namespace Mishmash.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Channels = new HashSet<UserInChannel>();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<UserInChannel> Channels { get; set; }
    }
}
