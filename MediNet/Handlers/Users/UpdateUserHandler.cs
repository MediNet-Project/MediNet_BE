using MediatR;
using MediNet.Commands.Users;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using StackExchange.Redis;
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;

namespace MediNet.Handlers.Users
{
    public class UpdateUserHandler: IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {

            var updateUser = await _unitOfWork.UserRepository.GetUserByIdAsync(command.Id);
            if (updateUser == null) return default;

            updateUser.UserName = command.UserName;
            updateUser.Email = command.Email;
            updateUser.Password = command.Password;
            updateUser.Role = command.Role;
            updateUser.Position = command.Position;
            updateUser.Phone = command.Phone;
            updateUser.Image = command.Image;
            
            return await _unitOfWork.UserRepository.UpdateUserAsync(updateUser);
        }
    }
}
