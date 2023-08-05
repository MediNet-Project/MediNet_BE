using MediNet.Context;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MediNet.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<List<Comment>> GetCommentListAsync()
        {
            var comments = await _dbContext.Comments.ToListAsync();
            return comments;
        }

        public async Task<Comment> GetCommentByIdAsync(int Id)
        {
            return await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<int> DeleteCommentAsync(int Id)
        {
            var filteredData = _dbContext.Comments.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Comments.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateCommentAsync(Comment Comment)
        {
            _dbContext.Comments.Update(Comment);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
