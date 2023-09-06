using MediatR;
using MediNet.Models;

namespace MediNet.Commands.Posts
{
    public class CreatePostCommand : IRequest<Post>
    {
        public string? Content { get; set; }
        public IFormFile? Image { get; set; }
        public int UserId { get; set; }
    }
}
