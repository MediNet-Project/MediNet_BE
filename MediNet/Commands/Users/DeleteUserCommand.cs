using MediatR;
using MediNet.Models;

namespace MediNet.Commands.Users
{
    public class DeleteUserCommand: IRequest<int>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id= id;
        }
    }
}
