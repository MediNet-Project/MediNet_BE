namespace MediNet.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? Position { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
