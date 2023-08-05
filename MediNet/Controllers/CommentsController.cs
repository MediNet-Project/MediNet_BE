using MediatR;
using MediNet.Commands.Comments;
using MediNet.Commands.Users;
using MediNet.Models;
using MediNet.Queries.Conments;
using MediNet.Queries.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediNet.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentList()
        {
            var listComment = await _mediator.Send(new GetCommentListQuery());
            return Ok(listComment);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var findComment = await _mediator.Send(new GetCommentByIdQuery(id));
            return Ok(findComment);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(Comment comment)
        {
            var isCommentUpdated = await _mediator.Send(new UpdateCommentCommand(
               comment.Id,
               comment.Content,
               comment.UserId,
               comment.PostId));
            return Ok(isCommentUpdated);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _mediator.Send(new DeleteCommentCommand(id));
            return Ok();
        }
    }
}
