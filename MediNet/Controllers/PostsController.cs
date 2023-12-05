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
        public async Task<IActionResult> CreatePost([FromForm] CreatePostCommand command)
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

        [HttpGet("get-most-like-post")]
        public async Task<IActionResult> GetMostLikePostList()
        {
            var listMostLikePost = await _mediator.Send(new GetMostLikePostQuery());
            return Ok(listMostLikePost);
        }

        [HttpGet("get-most-comment-post")]
        public async Task<IActionResult> GetMostCommentPostList()
        {
            var listMostCommentPost = await _mediator.Send(new GetMostCommentPostQuery());
            return Ok(listMostCommentPost);
        }

        [HttpPut("update-post")]
        public async Task<IActionResult> UpdatePost([FromForm] UpdatePostCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("reaction-post")]
        public async Task<IActionResult> ReactionPost([FromBody] ReactionPostCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /*[HttpPost("{entityType}/{entityId}")]
        public async Task<IActionResult> Toggle([FromRoute] int entityType, int entityId)
        {
            var userId = int.Parse(User.FindFirst("id")?.Value);
            return Ok(await _mediator.Send(new ToggleReactionCommand(userId, entityType, entityId)));
        }*/

        [HttpPatch("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _mediator.Send(new DeletePostCommand(id));
            return Ok();
        }

        [HttpPatch("block-post/{id}")]
        public async Task<IActionResult> BlockPost(int id)
        {
            await _mediator.Send(new BlockPostCommand(id));
            return Ok();
        }

        [HttpPatch("unblock-post/{id}")]
        public async Task<IActionResult> UnBlockPost(int id)
        {
            await _mediator.Send(new UnBlockPostCommand(id));
            return Ok();
        }

    }
}
