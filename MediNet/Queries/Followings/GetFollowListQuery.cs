using MediatR;
using MediNet.DTOs;
using MediNet.Models;

namespace MediNet.Queries.Followings
{
    public class GetFollowListQuery: IRequest<List<FollowDTO>>
    {
    }
}
