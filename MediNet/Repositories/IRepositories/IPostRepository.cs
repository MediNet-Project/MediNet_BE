using MediNet.Models;

namespace MediNet.Repositories.IRepositories
{
    public interface IPostRepository
    {
        Task<List<Post>> GetPostListAsync();
        Task<Post> GetPostByIdAsync(int Id);
        public Task<int> UpdatePostAsync(Post Post);
        public Task<int> DeletePostAsync(int Id);
    }
}
