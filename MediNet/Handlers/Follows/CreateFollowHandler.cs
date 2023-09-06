using MediatR;
using MediNet.Commands.Comments;
using MediNet.Commands.Follows;
using MediNet.Models;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Follows
{
    public class CreateFollowHandler: IRequestHandler<CreateFollowCommand, Following>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateFollowHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Following> Handle(CreateFollowCommand command, CancellationToken cancellationToken)
        {

            var newFollowing = new Following()
            {
                FollowingId = command.FollowingId,
                FollowerId = command.FollowerId
            };
            await _unitOfWork.Repository<Following>().AddAsync(newFollowing);
            await _unitOfWork.Save(cancellationToken);
            return newFollowing;
        }
    }
}
