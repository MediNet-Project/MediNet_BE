using MediatR;
using MediNet.Commands.Comments;
using MediNet.Models;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Comments
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, Comment>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCommentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Comment> Handle(CreateCommentCommand command, CancellationToken cancellationToken)
        {

            var newComment = new Comment()
            {
                Content = command.Content,
                UserId = command.UserId,
                PostId = command.PostId
            };
            await _unitOfWork.Repository<Comment>().AddAsync(newComment);
            await _unitOfWork.Save(cancellationToken);
            return newComment;
        }
    }
}
