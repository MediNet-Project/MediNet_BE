using MediNet.Context;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MediNet.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PostRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<List<Post>> GetPostListAsync()
        {
            var posts = await _dbContext.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post> GetPostByIdAsync(int Id)
        {
            return await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<int> DeletePostAsync(int Id)
        {
            var filteredData = _dbContext.Posts.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Posts.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdatePostAsync(Post Post)
        {
            _dbContext.Posts.Update(Post);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
