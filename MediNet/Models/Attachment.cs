namespace MediNet.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public int? PostId { get; set; }
        public Post? Post { get; set; }
    }
}
