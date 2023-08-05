using MediatR;

namespace MediNet.Commands.Posts
{
    public class UpdatePostCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public int? UserId { get; set; }

        public UpdatePostCommand(int id, string content, string image, int? userId)
        {
            Id = id;
            Content = content;
            Image = image;
            UserId = userId;
        }
    }
}
