using MediatR;
using MediNet.Models;

namespace MediNet.Queries.Posts
{
    public class GetPostListQuery: IRequest<List<Post>>
    {
    }
}
