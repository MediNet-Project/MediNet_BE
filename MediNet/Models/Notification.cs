namespace MediNet.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
        public int? FollowingId { get; set; }
        public int? GroupUserId { get; set; }
        public int? ReactionId { get; set; }
        public int? UserId { get; set; }
        public Post? Post { get; set; }
        public Comment? Comment { get; set; }
        public Following? Following { get; set; }
        public User? User { get; set; }
        public GroupUser? GroupUser { get; set; }
        public Reaction? Reaction { get; set; }
    }
}
