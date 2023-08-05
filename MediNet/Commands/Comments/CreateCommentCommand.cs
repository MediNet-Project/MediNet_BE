using MediatR;
using MediNet.Models;

namespace MediNet.Commands.Comments
{
    public class CreateCommentCommand: IRequest<Comment>
    {
        public string? Content { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }

        public CreateCommentCommand(string content, int? userId, int? postId)
        {
            Content = content;
            UserId = userId;
            PostId = postId;    
        }
    }
}
