using MediatR;
using MediNet.Models;

namespace MediNet.Commands.Users
{
    public class UpdateUserCommand: IRequest<User>
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Position { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }

        public UpdateUserCommand(string email, string password, string role, string position, string phone, string image)
        {
            Email = email;
            Password = password;
            Role = role;
            Position = position;
            Phone = phone;
            Image = image;
        }
    }
}
