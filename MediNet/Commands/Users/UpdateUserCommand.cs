using MediatR;
using MediNet.Models;

namespace MediNet.Commands.Users
{
    public class UpdateUserCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? Position { get; set; }
        public string? Phone { get; set; }
        

    }
}
