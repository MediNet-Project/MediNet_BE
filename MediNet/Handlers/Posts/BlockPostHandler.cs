using MediatR;
using MediNet.Commands.Posts;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Posts
{
    public class BlockPostHandler : IRequestHandler<BlockPostCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlockPostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(BlockPostCommand command, CancellationToken cancellationToken)
        {
            await _unitOfWork.PostRepository.BlockPostAsync(command.Id);
            return await Task.FromResult(0);
        }
    }
}
