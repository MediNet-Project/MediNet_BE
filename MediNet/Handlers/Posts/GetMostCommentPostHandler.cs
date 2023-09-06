using MediatR;
using MediNet.DTOs;
using MediNet.Queries.Posts;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Posts
{
    public class GetMostCommentPostHandler : IRequestHandler<GetMostCommentPostQuery, List<PostDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetMostCommentPostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PostDTO>> Handle(GetMostCommentPostQuery query, CancellationToken cancellationToken)
        {
            var posts = await _unitOfWork.PostRepository.GetMostCommentPostAsync();
            return posts;
        }
    }
}
