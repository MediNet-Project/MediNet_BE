using MediatR;

namespace MediNet.Commands.Posts
{
    public class DeletePostCommand : IRequest<int>
    {
        public int Id { get; set; }

        public DeletePostCommand(int id)
        {
            Id = id;
        }
    }
}
