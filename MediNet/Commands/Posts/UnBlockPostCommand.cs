using MediatR;

namespace MediNet.Commands.Posts
{
    public class UnBlockPostCommand : IRequest<int>
    {
        public int Id { get; set; }

        public UnBlockPostCommand(int id)
        {
            Id = id;
        }
    }
}
