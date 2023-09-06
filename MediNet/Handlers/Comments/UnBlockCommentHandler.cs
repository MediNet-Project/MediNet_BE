using MediatR;
using MediNet.Commands.Comments;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Comments
{
    public class UnBlockCommentHandler : IRequestHandler<UnBlockCommentCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnBlockCommentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UnBlockCommentCommand command, CancellationToken cancellationToken)
        {
            await _unitOfWork.CommentRepository.UnBlockCommentAsync(command.Id);
            return await Task.FromResult(0);
        }
    }
}
