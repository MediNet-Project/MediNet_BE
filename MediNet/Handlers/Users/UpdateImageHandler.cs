using MediatR;
using MediNet.Commands.Users;
using MediNet.Models;
using MediNet.Repositories;
using MediNet.Repositories.IRepositories;
using MediNet.Services.IServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MediNet.Handlers.Users
{
    public class UpdateImageHandler: IRequestHandler<UpdateImageCommand, int>
    {
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateImageHandler(IUnitOfWork unitOfWork, ICloudinaryService cloudinaryService)
        {
            _unitOfWork = unitOfWork;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<int> Handle(UpdateImageCommand command, CancellationToken cancellationToken)
        {
            var updateUser = await _unitOfWork.Repository<User>().GetByIdAsync(command.Id);
            if (updateUser == null) return default;

            updateUser.Image = command.Image == null ? null : await _cloudinaryService.UploadImage(command.Image);

            return await _unitOfWork.UserRepository.UpdateUserAsync(updateUser);
        }
    }
}
