using MediatR;
using MediNet.Models;

namespace MediNet.Commands.Posts
{
    public class CreatePostCommand : IRequest<Post>
    {
        public string? Content { get; set; }
        public string? Image { get; set; }
        public int? UserId { get; set; }

        public CreatePostCommand(string content, string image, int? userId)
        {
            Content = content;
            Image = image;
            UserId = userId;
        }


    }
}
