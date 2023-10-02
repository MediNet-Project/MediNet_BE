using MediNet.Context;
using MediNet.DTOs;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MediNet.Repositories
{
    public class FollowRepository: IFollowRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FollowRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<List<FollowDTO>> GetFollowListAsync()
        {
            /*var follows = await _dbContext.Followings.ToListAsync();
            return follows;*/
            var follows = await _dbContext.Followings.Select(f => new FollowDTO
            {
                Id = f.Id,
                FollowerId = f.FollowerId,
                FollowingId = f.FollowingId,
                UserName = f.Followings.UserName,
                Email = f.Followings.Email,
                Position = f.Followings.Position,
                Phone = f.Followings.Phone,
                Image = f.Followings.Image
            }).ToListAsync();
            return follows;
        }

        public async Task<int> DeleteFollowAsync(int Id)
        {
            var followData = _dbContext.Followings.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Followings.Remove(followData);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
