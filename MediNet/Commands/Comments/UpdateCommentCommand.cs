using MediatR;

namespace MediNet.Commands.Comments
{
    public class UpdateCommentCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }

        public UpdateCommentCommand(int id, string content, int? userId, int? postId)
        {
            Id = id;
            Content = content;
            UserId = userId;
            PostId = postId;
        }
    }
}
