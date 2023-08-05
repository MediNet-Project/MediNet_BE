using MediatR;
using MediNet.Commands.Comments;
using MediNet.Commands.Users;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Comments
{
    public class UpdateCommentHandler: IRequestHandler<UpdateCommentCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCommentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateCommentCommand command, CancellationToken cancellationToken)
        {

            var updateComment = await _unitOfWork.CommentRepository.GetCommentByIdAsync(command.Id);
            if (updateComment == null) return default;

            updateComment.Content = command.Content;
            updateComment.UserId = command.UserId;
            updateComment.PostId = command.PostId;

            return await _unitOfWork.CommentRepository.UpdateCommentAsync(updateComment);
        }
    }
}
