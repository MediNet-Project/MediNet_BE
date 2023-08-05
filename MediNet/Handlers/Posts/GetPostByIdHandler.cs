using MediatR;
using MediNet.Models;
using MediNet.Queries.Conments;
using MediNet.Queries.Posts;
using MediNet.Repositories.IRepositories;

namespace MediNet.Handlers.Posts
{
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, Post>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPostByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Post> Handle(GetPostByIdQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.PostRepository.GetPostByIdAsync(query.Id);
        }
    }
}
