using MediatR;
using MediNet.DTOs;
using MediNet.Models;

namespace MediNet.Commands.Users
{
    public class LoginUserCommand: IRequest<AuthResponseDTO>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
