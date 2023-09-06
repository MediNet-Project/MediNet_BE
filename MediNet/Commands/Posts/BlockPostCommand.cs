using MediatR;

namespace MediNet.Commands.Posts
{
    public class BlockPostCommand : IRequest<int>
    {
        public int Id { get; set; }

    public BlockPostCommand(int id)
    {
        Id = id;
    }
}
}
