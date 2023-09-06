using MediNet.Context;
using MediNet.Repositories.IRepositories;

namespace MediNet.Repositories
{
    public class FollowRepository: IFollowRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FollowRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<int> DeleteFollowAsync(int Id)
        {
            var followData = _dbContext.Followings.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Followings.Remove(followData);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
