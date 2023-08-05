using MediatR;
using MediNet.Models;

namespace MediNet.Queries.Conments
{
    public class GetCommentByIdQuery : IRequest<Comment>
    {
        public int Id { get; set; }

        public GetCommentByIdQuery (int id)
        {
            Id = id;
        }
    }
}
