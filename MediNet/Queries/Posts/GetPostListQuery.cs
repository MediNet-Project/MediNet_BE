using MediatR;
using MediNet.DTOs;
using MediNet.Models;

namespace MediNet.Queries.Posts
{
    public class GetPostListQuery: IRequest<List<PostDTO>>
    {
    }
}
