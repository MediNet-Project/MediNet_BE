using MediNet.DTOs;
using MediNet.Models;

namespace MediNet.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<List<UserDTO>> GetUserListAsync();
        Task<UserDTO> GetUserByIdAsync(int Id);
        public Task<List<UserDTO>> GetUserListHasMostPostAsync();
        public Task<int> UpdateUserAsync(User User);
        public Task<int> DeleteUserAsync(int Id);
        public Task<User> FindByEmail(string email);
        public Task<string> HashPassword(string password);

        public Task<int> UpdatePasswordAsync(int Id, string newPwd);
        Task<User> FindUser(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload);
    }
}
