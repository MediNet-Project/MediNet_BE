using MediatR;
using MediNet.Models;

namespace MediNet.Commands.Follows
{
    public class CreateFollowCommand: IRequest<Following>
    {
        public int? FollowingId { get; set; }
        public int? FollowerId { get; set; }
    }
}
