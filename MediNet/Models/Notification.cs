namespace MediNet.Models
{
    public class Notification : Common
    {
        public int Id { get; set; }
        public Enums.Type? Type { get; set; }
        public string? Content { get; set; }
        public int? EntityId { get; set; }
        public DateTimeOffset? CreatedDate { get; set; } = DateTimeOffset.Now;
        public ICollection<UserNotification>? UserNotifications { get; set; }
    }
}
