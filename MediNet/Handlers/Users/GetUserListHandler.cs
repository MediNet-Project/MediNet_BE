using MediatR;
using MediNet.DTOs;
using MediNet.Models;
using MediNet.Queries.Users;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Users
{
    public class GetUserListHandler: IRequestHandler<GetUserListQuery, List<UserDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserDTO>> Handle(GetUserListQuery query, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.UserRepository.GetUserListAsync();
            return users;
        }
    }
}
