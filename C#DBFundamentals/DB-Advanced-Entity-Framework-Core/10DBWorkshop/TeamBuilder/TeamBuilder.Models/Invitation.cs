namespace TeamBuilder.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public int InvitedUserId { get; set; }
        public User User { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
