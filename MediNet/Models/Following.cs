namespace MediNet.Models
{
    public class Following
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? FollowerId { get; set; }
        public User? User { get; set; }
        public ICollection<Notification>? Notifications { get; set; }

    }
}
