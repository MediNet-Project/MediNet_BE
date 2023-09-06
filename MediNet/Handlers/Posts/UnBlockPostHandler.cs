using MediatR;
using MediNet.Commands.Posts;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Posts
{
    public class UnBlockPostHandler : IRequestHandler<UnBlockPostCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnBlockPostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UnBlockPostCommand command, CancellationToken cancellationToken)
        {
            await _unitOfWork.PostRepository.UnBlockPostAsync(command.Id);
            return await Task.FromResult(0);
        }
    }
}
