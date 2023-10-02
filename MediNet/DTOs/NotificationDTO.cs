using MediNet.Models;
using System;

namespace MediNet.DTOs
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public Models.Enums.Type? Type { get; set; }
        public string? Content { get; set; }
        public int? EntityId { get; set; }
        public bool IsRead { get; set; }
        public DateTimeOffset? CreatedDate { get; set; } = DateTimeOffset.Now;
    }
}
