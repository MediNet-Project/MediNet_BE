using MediatR;
using MediNet.Commands.Comments;
using MediNet.Commands.Posts;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using MediNet.Services.IServices;

namespace MediNet.Handlers.Posts
{
    public class CreatePostHandler: IRequestHandler<CreatePostCommand, Post>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryService _cloudinaryService;
        public CreatePostHandler(IUnitOfWork unitOfWork, ICloudinaryService cloudinaryService)
        {
            _unitOfWork = unitOfWork;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<Post> Handle(CreatePostCommand command, CancellationToken cancellationToken)
        {

            var newPost = new Post()
            {
                Content = command.Content,
                Image = await _cloudinaryService.UploadImage(command.Image),
                UserId = command.UserId,
            };
            await _unitOfWork.Repository<Post>().AddAsync(newPost);
            await _unitOfWork.Save(cancellationToken);
            return newPost;
        }
    }
}
