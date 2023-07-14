namespace MediNet.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Position { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }
        public bool? IsDeleted { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<Group>? Groups { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Following>? Followings { get; set; }
        public ICollection<GroupUser>? GroupUsers { get; set; }
        public ICollection<Reaction>? Reactions { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
    }
}
