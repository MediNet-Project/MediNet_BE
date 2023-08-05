using MediatR;
using MediNet.Commands.Comments;
using MediNet.Commands.Users;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Comments
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCommentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
        {
            await _unitOfWork.CommentRepository.DeleteCommentAsync(command.Id);
            return await Task.FromResult(0);
        }
    }
}
