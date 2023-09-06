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
            var comments = await _dbContext.Comments.Where(x => x.IsBlocked == false).ToListAsync();
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

        public async Task<int> BlockCommentAsync(int Id)
        {
            var commentToBlock = _dbContext.Comments.FirstOrDefault(x => x.Id == Id);
            commentToBlock.IsBlocked = true;
            _dbContext.Comments.Update(commentToBlock);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UnBlockCommentAsync(int Id)
        {
            var commentToUnBlock = _dbContext.Comments.FirstOrDefault(x => x.Id == Id);
            commentToUnBlock.IsBlocked = false;
            _dbContext.Comments.Update(commentToUnBlock);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateCommentAsync(Comment Comment)
        {
            _dbContext.Comments.Update(Comment);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
