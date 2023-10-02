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
using MediNet.DTOs;

namespace MediNet.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var findUser = await _dbContext.Users.Include(x => x.Followings)
                           .Where(x => x.IsDeleted == false && x.Id == id)
                           .Select(x => new UserDTO
                           {
                               Id = x.Id,
                               UserName = x.UserName,
                               Email = x.Email,
                               Position =x.Position,
                               Role = x.Role,   
                               Image = x.Image,
                               Phone = x.Phone,
                               FollowingDTO = x.Followings.Where(c => c.FollowerId == id).Select(c => new FollowDTO
                               {
                                   Id = c.Id,
                                   FollowerId = c.FollowerId,
                                   FollowingId = c.FollowingId,
                                   UserName = c.Followings.UserName,
                                   Email = c.Followings.Email,
                                   Position = c.Followings.Position,
                                   Phone = c.Followings.Phone,
                                   Image = c.Followings.Image
                               }).ToList(),
                               FollowerDTO  = x.Followers.Where(c => c.FollowingId == id).Select(c => new FollowDTO
                               {
                                   Id = c.Id,
                                   FollowerId = c.FollowerId,
                                   FollowingId   = c.FollowingId,
                                   UserName = c.Followers.UserName,
                                   Email = c.Followers.Email,
                                   Position = c.Followers.Position,
                                   Phone = c.Followers.Phone,
                                   Image = c.Followers.Image
                               }).ToList(),
                           }).FirstOrDefaultAsync();
            return findUser == null ? null : findUser;
        }

        public async Task<List<UserDTO>> GetUserListAsync()
        {
            var users = await _dbContext.Users.Include(x => x.Followings).Where(x => x.IsDeleted == false)
                .Select(x => new UserDTO
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                Position = x.Position,
                Role = x.Role,
                Image = x.Image,
                Phone = x.Phone,
                    FollowingDTO = x.Followings.Where(c => c.FollowerId == x.Id).Select(c => new FollowDTO
                    {
                        Id = c.Id,
                        FollowerId = c.FollowerId,
                        FollowingId = c.FollowingId,
                        UserName = c.Followings.UserName,
                        Email = c.Followings.Email,
                        Position = c.Followings.Position,
                        Phone = c.Followings.Phone,
                        Image = c.Followings.Image
                    }).ToList(),
                    FollowerDTO = x.Followers.Where(c => c.FollowingId == x.Id).Select(c => new FollowDTO
                    {
                        Id = c.Id,
                        FollowerId = c.FollowerId,
                        FollowingId = c.FollowingId,
                        UserName = c.Followers.UserName,
                        Email = c.Followers.Email,
                        Position = c.Followers.Position,
                        Phone = c.Followers.Phone,
                        Image = c.Followers.Image
                    }).ToList(),
                }).OrderByDescending(x => x.Id).ToListAsync();
            return users;
        }

        public async Task<List<UserDTO>> GetUserListHasMostPostAsync()
        {
            var findUserId = _dbContext.Posts.Where(c => c.IsBlocked == false)
                                .GroupBy(r => r.UserId)
                                .Select(x => x.Key)
                                .ToArray();

            var mostPostUser = _dbContext.Users.Include(x => x.Posts)
                .Where(x => findUserId.Contains(x.Id))
                .OrderByDescending(x => x.Posts.Count())
                                  .Select(x => new UserDTO
                                  {
                                      Id = x.Id,
                                      UserName = x.UserName,
                                      Email = x.Email,
                                      Position = x.Position,
                                      Phone = x.Phone,
                                      Image = x.Image,
                                      PostCount = x.Posts.Count(),
                                  }).Take(3).ToList();

            return mostPostUser;
        }

        public async Task<int> DeleteUserAsync(int Id)
        {
            var userToDelete = _dbContext.Users.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
            var postsToDelete = _dbContext.Posts
                                .Where(x => x.UserId == userToDelete.Id)
                                .ToArray();
            var commentToDelete = _dbContext.Comments
                                .Where(x => x.UserId == userToDelete.Id)
                                .ToList();
            var likeToDelete = _dbContext.Reactions
                                .Where(x => x.UserId == userToDelete.Id)
                                .ToArray();
            _dbContext.Reactions.RemoveRange(likeToDelete);
            _dbContext.Comments.RemoveRange(commentToDelete);
            _dbContext.Posts.RemoveRange(postsToDelete);
            userToDelete.IsDeleted = true;
            _dbContext.Users.Update(userToDelete);
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

        public async Task<int> UpdatePasswordAsync(int Id, string newPwd)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == Id);
            user.Password = BCrypt.Net.BCrypt.HashPassword(newPwd);
            _dbContext.Users.Update(user);
            return await _dbContext.SaveChangesAsync();
        }
    

        public async Task<User> FindUser(GoogleJsonWebSignature.Payload payload)
        {
            var user = await _dbContext.Users.Where(x => x.IsDeleted == false && x.Email == payload.Email).FirstOrDefaultAsync();
            return user == null ? null : user;
        }
    }
}
