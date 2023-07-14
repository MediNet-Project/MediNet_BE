namespace MediNet.Models
{
    public class Common
    {
        public bool? IsDeleted { get; set; } = false;
        public string? CreatedBy { get; set; }
        public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.Now;
    }
}
