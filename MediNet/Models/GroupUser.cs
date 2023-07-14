namespace MediNet.Models
{
    public class GroupUser
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? UserId { get; set; }
        public DateTimeOffset? JoinDate { get; set; } = DateTimeOffset.Now;
        public User? User { get; set; }
        public Group? Group { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
    }
}
