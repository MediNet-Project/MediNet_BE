namespace MediNet.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string? Content { get; set; }
        public bool? IsBlocked { get; set; }

        public UserDTO UserDTO { get; set; }

        public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.Now;
    }
}
