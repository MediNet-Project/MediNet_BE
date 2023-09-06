namespace MediNet.Models
{
    public class Following
    {
        public int Id { get; set; } 
        public int? FollowingId { get; set; }
        public int? FollowerId { get; set; }
        public User? Followers { get; set; }
        public User? Followings { get; set; }
        public ICollection<Notification>? Notifications { get; set; }

    } 
}
     