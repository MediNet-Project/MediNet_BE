namespace MediNet.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public int UserId { get; set; }
        public int? LikeCount { get; set; }
        public int? CommentCount { get; set; }

        public bool? IsBlocked { get; set; }

        public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.Now;
        public UserDTO UserDTO { get; set; }
        public List<ReactionDTO> ReactionDTO { get; set; }
        public List<CommentDTO>? CommentDTO { get; set; }

    }
}
