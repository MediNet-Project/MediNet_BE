using MediatR;
using MediNet.Commands.Users;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using System.Runtime.Intrinsics.X86;

namespace MediNet.Handlers.Users
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            //var findUser = await _unitOfWork.UserRepository.GetUserByIdAsync(command.Id);
            //if (findUser == null)
            //    return default;
            //findUser.IsDeleted = true;
            await _unitOfWork.UserRepository.DeleteUserAsync(command.Id);
            return await Task.FromResult(0);
        }
    }
}
