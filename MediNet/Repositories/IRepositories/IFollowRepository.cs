using MediNet.DTOs;
using MediNet.Models;

namespace MediNet.Repositories.IRepositories
{
    public interface IFollowRepository
    {

        public Task<List<FollowDTO>> GetFollowListAsync();
        public Task<int> DeleteFollowAsync(int Id);
    }
}
