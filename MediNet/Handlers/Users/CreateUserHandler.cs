using MediatR;
using MediNet.Commands.Users;
using MediNet.Models;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            
            var newUser = new User()
            {
                Email = command.Email,
                Password = command.Password,
                Role = command.Role,
                Position = command.Position,
                Phone = command.Phone,
                Image = command.Image,
                IsDeleted = false
            };
            await _unitOfWork.Repository<User>().AddAsync(newUser);
            await _unitOfWork.Save(cancellationToken);
            return newUser;
        }
    }
}

