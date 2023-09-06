using MediatR;
using MediNet.Commands.Users;
using MediNet.Models;
using MediNet.Queries.Posts;
using MediNet.Queries.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MediNet.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("loginGoogle")]
        public async Task<IActionResult> LoginUserByGoogle([FromBody] string credential)
        {
            return Ok(await _mediator.Send(new LoginGoogleCommand(credential)));
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("get-list-user")]
        public async Task<IActionResult> GetUserList()
        {
            var listUser =  await _mediator.Send(new GetUserListQuery());
            return Ok(listUser);
        }

        [HttpGet("get-user-detail/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var findUser = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(findUser);
        }

        [HttpGet("get-user-has-most-post")]
        public async Task<IActionResult> GetMostLikePostList()
        {
            var listUserHasMostPost = await _mediator.Send(new GetUserHasMostPostQuery());
            return Ok(listUserHasMostPost);
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {           
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("update-image-user")]
        public async Task<IActionResult> UpdateImageUser([FromForm] UpdateImageCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPatch("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] UpdatePasswordCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return Ok();
        }

        

        //[HttpPost("refresh")]
        //public async Task<IActionResult> Refresh([FromBody] RefreshUserCommand command)
        //{
        //    return Ok(await _mediator.Send(command));
        //}
    }
}
