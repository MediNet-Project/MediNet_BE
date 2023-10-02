using MediatR;
using MediNet.Commands.Comments;
using MediNet.Commands.Follows;
using MediNet.Queries.Conments;
using MediNet.Queries.Followings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediNet.Controllers
{
    [Route("api/follows")]
    [ApiController]
    public class FollowsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FollowsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-follow")]
        public async Task<IActionResult> CreateFollow([FromBody] CreateFollowCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("get-list-follow")]
        public async Task<IActionResult> GetfollowList()
        {
            var listFollow = await _mediator.Send(new GetFollowListQuery());
            return Ok(listFollow);
        }

        [HttpPatch("delete-follow/{id}")]
        public async Task<IActionResult> DeleteFollow(int id)
        {
            await _mediator.Send(new DeleteFollowCommand(id));
            return Ok();
        }
    }
}
