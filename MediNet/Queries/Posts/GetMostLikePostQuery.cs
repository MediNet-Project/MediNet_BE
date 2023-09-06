using MediatR;
using MediNet.DTOs;

namespace MediNet.Queries.Posts
{
    public class GetMostLikePostQuery: IRequest<List<PostDTO>>
    {
    }
}
