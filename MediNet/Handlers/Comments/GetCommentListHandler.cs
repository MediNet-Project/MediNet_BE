using MediatR;
using MediNet.Models;
using MediNet.Queries.Conments;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Comments
{
    public class GetCommentListHandler : IRequestHandler<GetCommentListQuery, List<Comment>>
    {
        private readonly IUnitOfWork _unitOfWork;
    public GetCommentListHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Comment>> Handle(GetCommentListQuery query, CancellationToken cancellationToken)
    {
        var comments = await _unitOfWork.CommentRepository.GetCommentListAsync();
        return comments;
    }
    }
}
