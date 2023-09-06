using MediatR;
using MediNet.DTOs;
using MediNet.Models;
using MediNet.Queries.Users;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Users
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UserRepository.GetUserByIdAsync(query.Id);
        }
    }
}
