using MediatR;
using MediNet.Commands.Users;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Users
{
    public class UpdatePasswordHandler : IRequestHandler<UpdatePasswordCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePasswordHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdatePasswordCommand command, CancellationToken cancellationToken)
        {
            await _unitOfWork.UserRepository.UpdatePasswordAsync(command.Id, command.Password);
            return await Task.FromResult(0);
        }
    }
}
