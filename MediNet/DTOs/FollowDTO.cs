namespace MediNet.DTOs
{
    public class FollowDTO
    {
        public int Id { get; set; }
        public int? FollowingId { get; set; }
        public int? FollowerId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set;}
        public string? Position { get; set; }

        public string? Phone { get; set; }
        public string? Image { get; set; }
    }
}
