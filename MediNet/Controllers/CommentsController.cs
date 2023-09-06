using MediatR;
using MediNet.Commands.Comments;
using MediNet.Commands.Users;
using MediNet.Models;
using MediNet.Queries.Conments;
using MediNet.Queries.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MediNet.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-comment")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("get-list-comment")]
        public async Task<IActionResult> GetCommentList()
        {
            var listComment = await _mediator.Send(new GetCommentListQuery());
            return Ok(listComment);
        }

        [HttpGet("get-comment/{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var findComment = await _mediator.Send(new GetCommentByIdQuery(id));
            return Ok(findComment);
        }

        [HttpPut("update-comment")]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPatch("delete-comment/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _mediator.Send(new DeleteCommentCommand(id));
            return Ok();
        }

        [HttpPatch("block-comment/{id}")]
        public async Task<IActionResult> BlockComment(int id)
        {
            await _mediator.Send(new BlockCommentCommand(id));
            return Ok();
        }

        [HttpPatch("unblock-comment/{id}")]
        public async Task<IActionResult> UnBlockComment(int id)
        {
            await _mediator.Send(new UnBlockCommentCommand(id));
            return Ok();
        }
    }
}
