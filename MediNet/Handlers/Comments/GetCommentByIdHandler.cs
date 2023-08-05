using MediatR;
using MediNet.Models;
using MediNet.Queries.Conments;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Comments
{
    public class GetCommentByIdHandler : IRequestHandler<GetCommentByIdQuery, Comment>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCommentByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Comment> Handle(GetCommentByIdQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CommentRepository.GetCommentByIdAsync(query.Id);
        }
    }
}
