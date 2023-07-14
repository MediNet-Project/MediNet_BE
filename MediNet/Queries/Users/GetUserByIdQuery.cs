using MediatR;
using MediNet.Models;

namespace MediNet.Queries.Users
{
    public class GetUserByIdQuery: IRequest<User>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
