using MediatR;
using MediNet.Commands.Users;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using MediNet.Services.IServices;

namespace MediNet.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserHandler(IUnitOfWork unitOfWork, ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
            _unitOfWork = unitOfWork;
        }
        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            
            var newUser = new User()
            {
                Email = command.Email,
                UserName = command.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(command.Password),
                Role = command.Role,
                Position = command.Position,
                Phone = command.Phone,
                Image = null,
                /*Image = await _cloudinaryService.UploadImage(command.Image),*/
                IsDeleted = false
            };
            await _unitOfWork.Repository<User>().AddAsync(newUser);
            await _unitOfWork.Save(cancellationToken);
            return newUser;
        }
    }
}

