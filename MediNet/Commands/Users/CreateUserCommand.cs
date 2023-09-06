using MediatR;
using MediNet.Models;

namespace MediNet.Commands.Users
{
    public class CreateUserCommand : IRequest<User>
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Position { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }
       
        /*public CreateUserCommand(string email, string userName, string password, string role, string position, string phone, IFormFile image)
        {
            UserName = userName;
            Email = email;  
            Password = password;
            Role = role;
            Position = position;
            Phone = phone;
            Image = image;
        }*/
    }
}
