using MediNet.Models.Enums;

namespace MediNet.Models
{
    public class Group : Common
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public GroupState? GroupState { get; set; }
        public ICollection<GroupUser>? GroupUsers { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
