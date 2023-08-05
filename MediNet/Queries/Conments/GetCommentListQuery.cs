using MediatR;
using MediNet.Models;

namespace MediNet.Queries.Conments
{
    public class GetCommentListQuery: IRequest<List<Comment>>
    {
    }
}
