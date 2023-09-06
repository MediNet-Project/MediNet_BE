using MediatR;

namespace MediNet.Commands.Users
{
    public class UpdateImageCommand: IRequest<int>
    {
        public int Id { get; set; }
        public IFormFile? Image { get; set; }
    }
}
