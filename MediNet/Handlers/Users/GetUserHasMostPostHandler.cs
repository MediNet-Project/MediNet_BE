using MediatR;
using MediNet.DTOs;
using MediNet.Queries.Posts;
using MediNet.Queries.Users;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Users
{
    public class GetUserHasMostPostHandler : IRequestHandler<GetUserHasMostPostQuery, List<UserDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserHasMostPostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserDTO>> Handle(GetUserHasMostPostQuery query, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.UserRepository.GetUserListHasMostPostAsync();
            return users;
        }
    }
}
