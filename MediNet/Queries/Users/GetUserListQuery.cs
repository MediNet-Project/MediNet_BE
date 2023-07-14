using MediatR;
using MediNet.Models;

namespace MediNet.Queries.Users
{
    public class GetUserListQuery: IRequest<List<User>>
    {
        
    }
}
