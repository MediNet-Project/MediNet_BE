using MediatR;
using MediNet.DTOs;
using MediNet.Models;

namespace MediNet.Queries.Users
{
    public class GetUserByIdQuery: IRequest<UserDTO>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
