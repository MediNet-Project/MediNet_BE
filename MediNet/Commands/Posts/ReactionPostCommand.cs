using MediatR;
using MediNet.Models;

namespace MediNet.Commands.Posts
{
    public class ReactionPostCommand: IRequest<Reaction>
    {
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public bool? Like { get; set; }

    }
}
