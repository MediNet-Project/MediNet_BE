using MediNet.Models;

namespace MediNet.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUserListAsync();
        Task<User> GetUserByIdAsync(int Id);
        //public Task<User> AddUserAsync(User user);
        public Task<int> UpdateUserAsync(User user);
        public Task<int> DeleteUserAsync(int Id);
    }
}
