using MediatR;
using MediNet.Models;
using MediNet.Queries.Users;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Users
{
    public class GetUserListHandler: IRequestHandler<GetUserListQuery, List<User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> Handle(GetUserListQuery query, CancellationToken cancellationToken)
        {
            var projects = await _unitOfWork.UserRepository.GetUserListAsync();
            return projects;
        }
    }
}
