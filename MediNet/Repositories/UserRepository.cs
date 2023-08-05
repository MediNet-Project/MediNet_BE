 using MediNet.Context;
using Google.Apis.Auth;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace MediNet.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public UserRepository(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;

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

        public async Task<int> UpdateUserAsync(User User)
        {
            _dbContext.Users.Update(User);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<User> FindByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.IsDeleted == false);
        }

        public async Task<string> HashPassword(string password)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(password);
            return hash;
        }

        public async Task<User> FindUser(GoogleJsonWebSignature.Payload payload)
        {
            var user = await _dbContext.Users.Where(x => x.IsDeleted == false && x.Email == payload.Email).FirstOrDefaultAsync();
            return user == null ? null : user;
        }
    }
}
