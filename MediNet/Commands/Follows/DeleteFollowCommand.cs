using MediatR;

namespace MediNet.Commands.Follows
{
    public class DeleteFollowCommand: IRequest<int>
    {
        public int Id { get; set; }

        public DeleteFollowCommand(int id)
        {
            Id = id;
        }
    }
}
