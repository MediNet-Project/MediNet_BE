using MediatR;

namespace MediNet.Commands.Comments
{
    public class DeleteCommentCommand: IRequest<int>
    {
        public int Id { get; set; }

        public DeleteCommentCommand(int id)
        {
            Id = id;
        }
    }
}
