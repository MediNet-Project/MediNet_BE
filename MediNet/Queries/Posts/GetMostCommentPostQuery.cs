using MediatR;
using MediNet.DTOs;

namespace MediNet.Queries.Posts
{
    public class GetMostCommentPostQuery: IRequest<List<PostDTO>>
    {
    }
}
