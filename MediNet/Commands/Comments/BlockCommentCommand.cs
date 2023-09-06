using MediatR;

namespace MediNet.Commands.Comments
{
    public class BlockCommentCommand : IRequest<int>
    {
        public int Id { get; set; }

        public BlockCommentCommand(int id)
        {
            Id = id;
        }
    }
}
