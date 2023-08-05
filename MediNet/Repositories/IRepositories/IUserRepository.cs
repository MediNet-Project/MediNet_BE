using MediNet.Models;

namespace MediNet.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUserListAsync();
        Task<User> GetUserByIdAsync(int Id);
        //public Task<User> AddUserAsync(User user);
        public Task<int> UpdateUserAsync(User User);
        public Task<int> DeleteUserAsync(int Id);
        public Task<User> FindByEmail(string email);
        public Task<string> HashPassword(string password);
        Task<User> FindUser(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload);
    }
}
