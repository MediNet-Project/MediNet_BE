using MediatR;
using MediNet.Models;
using MediNet.Queries.Users;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Users
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UserRepository.GetUserByIdAsync(query.Id);
        }
    }
}
