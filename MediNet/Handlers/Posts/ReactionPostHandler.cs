using MediatR;
using MediNet.Commands.Posts;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MediNet.Handlers.Posts
{
    public class ReactionPostHandler : IRequestHandler<ReactionPostCommand, Reaction>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReactionPostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Reaction> Handle(ReactionPostCommand command, CancellationToken cancellationToken)
        {
            var userReaction = await _unitOfWork.PostRepository.LikePostAsync(command.UserId,command.PostId);
            return userReaction;
        }
    }
}
