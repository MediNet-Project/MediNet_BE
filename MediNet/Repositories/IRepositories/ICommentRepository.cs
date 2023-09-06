using MediNet.Models;

namespace MediNet.Repositories.IRepositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentListAsync();
        Task<Comment> GetCommentByIdAsync(int Id);
        public Task<int> UpdateCommentAsync(Comment Comment);
        public Task<int> DeleteCommentAsync(int Id);
        public Task<int> BlockCommentAsync(int Id);
        public Task<int> UnBlockCommentAsync(int Id);
    }
}
