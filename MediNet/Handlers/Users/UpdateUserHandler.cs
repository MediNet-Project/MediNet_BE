using MediatR;
using MediNet.Commands.Users;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using StackExchange.Redis;
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;

namespace MediNet.Handlers.Users
{
    public class UpdateUserHandler: IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {

            var user = await _unitOfWork.Repository<User>().GetByIdAsync(command.Id);
            if (user == null)
                return default;
           
                user.Email = command.Email;
                user.Password = command.Password;
                user.Role = command.Role;
                user.Position = command.Position;
                user.Phone = command.Phone;
                user.Image = command.Image;

            await _unitOfWork.UserRepository.UpdateUserAsync(user);
            await _unitOfWork.Save(cancellationToken);
            return user;
        }
    }
}
