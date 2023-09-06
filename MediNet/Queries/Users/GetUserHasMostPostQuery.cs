using MediatR;
using MediNet.DTOs;
using MediNet.Models;

namespace MediNet.Queries.Users
{
    public class GetUserHasMostPostQuery: IRequest<List<UserDTO>>
    {
    }
}
