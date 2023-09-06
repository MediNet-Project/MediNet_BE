using MediNet.DTOs;
using MediNet.Models;

namespace MediNet.Repositories.IRepositories
{
    public interface IPostRepository
    {
        Task<List<PostDTO>> GetPostListAsync();
        Task<Post> GetPostByIdAsync(int Id);
        public Task<int> UpdatePostAsync(Post Post);
        public Task<Reaction> LikePostAsync(int? userId, int? postId);
        public Task<int> DeletePostAsync(int Id);
        public Task<int> BlockPostAsync(int Id);

        public Task<int> UnBlockPostAsync(int Id);
        public Task<List<PostDTO>> GetMostLikePostAsync();
        public Task<List<PostDTO>> GetMostCommentPostAsync();
    }
}
