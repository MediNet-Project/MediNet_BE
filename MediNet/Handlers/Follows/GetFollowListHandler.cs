using MediatR;
using MediNet.DTOs;
using MediNet.Models;
using MediNet.Queries.Followings;
using MediNet.Queries.Posts;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Follows
{
    public class GetFollowListHandler : IRequestHandler<GetFollowListQuery, List<FollowDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetFollowListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<FollowDTO>> Handle(GetFollowListQuery query, CancellationToken cancellationToken)
        {
            var follows = await _unitOfWork.FollowRepository.GetFollowListAsync();
            return follows;
        }
    }
}
