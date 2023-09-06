using MediatR;
using MediNet.DTOs;
using MediNet.Models;
using MediNet.Queries.Conments;
using MediNet.Queries.Posts;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Posts
{
    public class GetPostListHandler : IRequestHandler<GetPostListQuery, List<PostDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPostListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PostDTO>> Handle(GetPostListQuery query, CancellationToken cancellationToken)
        {
            var posts = await _unitOfWork.PostRepository.GetPostListAsync();
            return posts;
        }
    }
}
