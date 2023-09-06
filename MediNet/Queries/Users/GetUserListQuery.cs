using MediatR;
using MediNet.DTOs;
using MediNet.Models;

namespace MediNet.Queries.Users
{
    public class GetUserListQuery: IRequest<List<UserDTO>>
    {
        
    }
}
