namespace MediNet.Models
{
    public class Comment : Common
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public User? User { get; set; }
        public Post? Post { get; set; }
        public ICollection<Notification>? Notifications { get; set; }

    }
}
