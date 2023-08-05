using MediatR;
using MediNet.Models;
using MediNet.Queries.Conments;
using MediNet.Queries.Posts;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Posts
{
    public class GetPostListHandler : IRequestHandler<GetPostListQuery, List<Post>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPostListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Post>> Handle(GetPostListQuery query, CancellationToken cancellationToken)
        {
            var posts = await _unitOfWork.PostRepository.GetPostListAsync();
            return posts;
        }
    }
}
