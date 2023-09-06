using MediNet.Context;
using MediNet.DTOs;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MediNet.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PostRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<List<PostDTO>> GetPostListAsync()
        {
            var users = await _dbContext.Users.ToListAsync();

            var userDTOs = users.ToDictionary(user => user.Id, user => ConvertUserToDTO(user));
            var posts = await _dbContext.Posts.Include(x => x.Reactions).Include(x => x.Comments).Include(x => x.User)
                .Select(x => new PostDTO()
                {
                    Id = x.Id,
                    Content = x.Content,
                    Image = x.Image,
                    UserId = x.UserId,
                    UserDTO = userDTOs[x.UserId],
                    LikeCount = x.Reactions.Count(n => n.Like == true),
                    CommentCount = x.Comments.Count(),
                    CreatedAt = DateTime.UtcNow,
                    IsBlocked = x.IsBlocked,
                    ReactionDTO = x.Reactions.Select(t => new ReactionDTO()
                    {
                        UserId = t.UserId,
                        Like = t.Like,
                    }).ToList(),
                    CommentDTO = x.Comments.Select(c => new CommentDTO()
                    {
                        UserDTO = userDTOs[c.UserId],
                        Id = c.Id,
                        UserId = c.UserId,
                        PostId = c.PostId,
                        Content = c.Content,
                        IsBlocked = c.IsBlocked,
                        CreatedAt = DateTime.UtcNow,
                    }).OrderByDescending(c => c.Id).ToList(),
                }).OrderByDescending(x => x.Id).ToListAsync();
            return posts;
        }

        public UserDTO ConvertUserToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Position = user.Position,
                Image = user.Image,
            };
        }

        public async Task<Post> GetPostByIdAsync(int Id)
        {
            return await _dbContext.Posts.FirstOrDefaultAsync(x => x.IsDeleted==false && x.Id == Id);
                        
        }

        public async Task<int> DeletePostAsync(int Id)
        {
            var postToDelete = _dbContext.Posts.Where(x => x.Id == Id).FirstOrDefault();
            var commentToDelete = _dbContext.Comments
                                .Where(x => x.PostId == postToDelete.Id)
                                .ToList();
            var likeToDelete = _dbContext.Reactions
                                .Where(x => x.PostId == postToDelete.Id)
                                .ToArray();
            _dbContext.Reactions.RemoveRange(likeToDelete);
            _dbContext.Comments.RemoveRange(commentToDelete);
            _dbContext.Posts.Remove(postToDelete);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> BlockPostAsync(int Id)
        {
            var postToBlock = _dbContext.Posts.FirstOrDefault(x => x.Id == Id);
            postToBlock.IsBlocked = true;
            _dbContext.Posts.Update(postToBlock);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UnBlockPostAsync(int Id)
        {
            var postToUnBlock = _dbContext.Posts.FirstOrDefault(x => x.Id == Id);
            postToUnBlock.IsBlocked = false;
            _dbContext.Posts.Update(postToUnBlock);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdatePostAsync(Post Post)
        {
            _dbContext.Posts.Update(Post);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Reaction> LikePostAsync(int? userId, int? postId)
        {
            var userReaction = _dbContext.Reactions.Where(i => (i.UserId == userId && i.PostId == postId)).FirstOrDefault();

            if (userReaction == null)
            {
                var reactionToLike = new Reaction
                {
                    UserId = userId,
                    PostId = postId,
                    Like = true
                };

                _dbContext.Reactions.Add(reactionToLike);
                await _dbContext.SaveChangesAsync();
                return reactionToLike;
            }

            if (userReaction.Like == true)
            {
                _dbContext.Reactions.Remove(userReaction);
                await _dbContext.SaveChangesAsync();
                return userReaction;
            }

            if (userReaction.Like == false)
            {
                userReaction.Like = true;
                _dbContext.Reactions.Update(userReaction);
                await _dbContext.SaveChangesAsync();
                return userReaction;
            }

            return userReaction;
        }

        public async Task<List<PostDTO>> GetMostLikePostAsync()
        {
            var findPostIdMostLike = (from r in _dbContext.Reactions
                              where r.Like == true
                              group r by r.PostId into GroupPost
                              select new Post
                              {
                                  Id = (int)GroupPost.Key
                              }).ToArray();

            var mostLikePost = _dbContext.Posts.Include(x => x.Reactions)
                .Where(x => findPostIdMostLike.Contains(x))
                .OrderByDescending(x => x.Reactions.Count(x => x.Like == true))
                                .Select(x => new PostDTO
                                {
                                    Id = x.Id,
                                    Content = x.Content,
                                    Image = x.Image,
                                    LikeCount = x.Reactions.Count(x => x.Like == true),
                                    CommentCount = x.Comments.Count(),
                                }).Take(3).ToList();

            return mostLikePost;
        }
        public async Task<List<PostDTO>> GetMostCommentPostAsync()
        {
            var findPostId = _dbContext.Comments
                                .GroupBy(r => r.PostId)
                                .Select(x => x.Key)
                                .ToArray();

            var mostCommentIdea = _dbContext.Posts.Include(x => x.Comments)
                .Where(x => findPostId.Contains(x.Id))
                .OrderByDescending(x => x.Comments.Count())
                                  .Select(x => new PostDTO
                                  {
                                      Id = x.Id,
                                      Content = x.Content,
                                      Image = x.Image,
                                      LikeCount = x.Reactions.Count(x => x.Like == true),
                                      CommentCount = x.Comments.Count(),
                                  }).Take(3).ToList();

            return mostCommentIdea;
        }
    }
}
