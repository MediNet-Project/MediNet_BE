using MediatR;
using MediNet.Commands.Posts;
using MediNet.Commands.Users;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Posts
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeletePostCommand command, CancellationToken cancellationToken)
        {
            await _unitOfWork.PostRepository.DeletePostAsync(command.Id);
            return await Task.FromResult(0);
        }
    }
}
