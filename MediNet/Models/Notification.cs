namespace MediNet.Models
{
    public class Notification : Common
    {
        /*public int Id { get; set; }
        public Models.Enums.Type? Type { get; set; }
        public string? Message { get; set; }
        public bool? IsRead { get; set; }
        public int? UserId { get; set; }
        public int? ReceiverId { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
        public int? FollowingId { get; set; }
        public int? ReactionId { get; set; }
        public Post? Post { get; set; }
        public Comment? Comment { get; set; }
        public Following? Following { get; set; }
        public User? User { get; set; }
        public Reaction? Reaction { get; set; }*/

        public int Id { get; set; }
        public Enums.Type? Type { get; set; }
        public string? Content { get; set; }
        public int? EntityId { get; set; }
        public DateTimeOffset? CreatedDate { get; set; } = DateTimeOffset.Now;
        public ICollection<UserNotification>? UserNotifications { get; set; }
    }
}
