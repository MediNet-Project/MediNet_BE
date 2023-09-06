using MediatR;
using MediNet.Commands.Comments;
using MediNet.Commands.Follows;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MediNet.Handlers.Follows
{
    public class DeleteFollowHandler : IRequestHandler<DeleteFollowCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteFollowHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteFollowCommand command, CancellationToken cancellationToken)
        {
            await _unitOfWork.FollowRepository.DeleteFollowAsync(command.Id);
            return await Task.FromResult(0);
        }
    }
}
