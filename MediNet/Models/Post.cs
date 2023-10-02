    namespace MediNet.Models
{
    public class Post : Common
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }        
        public ICollection<Attachment>? Attachments { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Reaction>? Reactions { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
    }
}
