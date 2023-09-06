namespace MediNet.Models
{
    public class Common
    {
        public bool? IsDeleted { get; set; } = false;
        public string? CreatedBy { get; set; }
        public bool? IsBlocked { get; set; } = false;
        public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.Now;
    }
}
