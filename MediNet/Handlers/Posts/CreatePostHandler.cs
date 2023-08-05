using MediatR;
using MediNet.Commands.Comments;
using MediNet.Commands.Posts;
using MediNet.Models;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Posts
{
    public class CreatePostHandler: IRequestHandler<CreatePostCommand, Post>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Post> Handle(CreatePostCommand command, CancellationToken cancellationToken)
        {

            var newPost = new Post()
            {
                Content = command.Content,
                Image = command.Image,
                UserId = command.UserId
            };
            await _unitOfWork.Repository<Post>().AddAsync(newPost);
            await _unitOfWork.Save(cancellationToken);
            return newPost;
        }
    }
}
