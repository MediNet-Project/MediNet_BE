namespace MediNet.Models
{
    public class Reaction
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public bool? Like { get; set; }
        public User? User { get; set; }
        public Post? Post { get; set; }
    }
}
