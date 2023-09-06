using MediatR;

namespace MediNet.Commands.Comments
{
    public class UnBlockCommentCommand : IRequest<int>
    {
        public int Id { get; set; }

        public UnBlockCommentCommand(int id)
        {
            Id = id;
        }
    }
}
