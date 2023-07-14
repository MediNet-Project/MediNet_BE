using MediNet.Context;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MediNet.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetUserByIdAsync(int Id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id == Id);
        }

        public async Task<List<User>> GetUserListAsync()
        {
            var users = await _dbContext.Users.Where(x => x.IsDeleted == false).ToListAsync();
            return users;
        }

        public async Task<int> DeleteUserAsync(int Id)
        {
            var filteredData = _dbContext.Users.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
            filteredData.IsDeleted = true;
            _dbContext.Users.Update(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateUserAsync(User Users)
        {
            _dbContext.Users.Update(Users);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
