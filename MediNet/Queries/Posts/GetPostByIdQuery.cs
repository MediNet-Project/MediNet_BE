using MediatR;
using MediNet.Models;

namespace MediNet.Queries.Posts
{
    public class GetPostByIdQuery : IRequest<Post>
    {
        public int Id { get; set; }

        public GetPostByIdQuery(int id)
        {
            Id = id;
        }
    }
}
