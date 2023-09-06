using MediatR;
using MediNet.Commands.Comments;
using MediNet.Commands.Posts;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Comments
{
    public class BlockCommentHandler : IRequestHandler<BlockCommentCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlockCommentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(BlockCommentCommand command, CancellationToken cancellationToken)
        {
            await _unitOfWork.CommentRepository.BlockCommentAsync(command.Id);
            return await Task.FromResult(0);
        }
    }
}
