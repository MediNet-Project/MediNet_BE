using MediatR;
using MediNet.Commands.Comments;
using MediNet.Commands.Posts;
using MediNet.Repositories.IRepositories;
using MediNet.Services.IServices;

namespace MediNet.Handlers.Posts
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryService _cloudinaryService;
        public UpdatePostHandler(IUnitOfWork unitOfWork, ICloudinaryService cloudinaryService)
        {
            _unitOfWork = unitOfWork;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<int> Handle(UpdatePostCommand command, CancellationToken cancellationToken)
        {

            var updatePost = await _unitOfWork.PostRepository.GetPostByIdAsync(command.Id);
            if (updatePost == null) return default;

            updatePost.Content = command.Content;
            updatePost.Image = command.Image == null ? null : await _cloudinaryService.UploadImage(command.Image);
            updatePost.UserId = command.UserId;

            return await _unitOfWork.PostRepository.UpdatePostAsync(updatePost);
        }
    }
}
