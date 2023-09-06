using MediatR;
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;

namespace MediNet.Commands.Users
{
    public class UpdatePasswordCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string? Password { get; set; }

        public UpdatePasswordCommand(int id, string password)
        {
            Id = id;
            Password = password;
        }
    }
}
