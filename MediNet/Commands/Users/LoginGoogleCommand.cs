using MediatR;
using MediNet.DTOs;
using MediNet.Models;

namespace MediNet.Commands.Users
{
    public class LoginGoogleCommand : IRequest<AuthResponseDTO>
    {
        public string? TokenId { get; set; }

        public LoginGoogleCommand(string tokenId)
        {
            TokenId = tokenId;
        }
    }
}
