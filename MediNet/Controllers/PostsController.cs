using MediatR;
using MediNet.Commands.Comments;
using MediNet.Commands.Posts;
using MediNet.Models;
using MediNet.Queries.Conments;
using MediNet.Queries.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediNet.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-post")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("get-list-post")]
        public async Task<IActionResult> GetPostList()
        {
            var listPost = await _mediator.Send(new GetPostListQuery());
            return Ok(listPost);
        }

        [HttpGet("get-post-detail/{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var findPost = await _mediator.Send(new GetPostByIdQuery(id));
            return Ok(findPost);
        }

        [HttpPut("update-post")]
        public async Task<IActionResult> UpdatePost(Post post)
        {
            var isPostUpdated = await _mediator.Send(new UpdatePostCommand(
               post.Id,
               post.Content,
               post.Image,
               post.UserId));
            return Ok(isPostUpdated);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _mediator.Send(new DeletePostCommand(id));
            return Ok();
        }
    }
}
