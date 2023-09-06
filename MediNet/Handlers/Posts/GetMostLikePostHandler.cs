using MediatR;
using MediNet.DTOs;
using MediNet.Queries.Posts;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Posts
{
    public class GetMostLikePostHandler: IRequestHandler<GetMostLikePostQuery, List<PostDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetMostLikePostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PostDTO>> Handle(GetMostLikePostQuery query, CancellationToken cancellationToken)
        {
            var posts = await _unitOfWork.PostRepository.GetMostLikePostAsync();
            return posts;
        }
    }
}
