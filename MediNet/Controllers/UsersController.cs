using MediatR;
using MediNet.Commands.Users;
using MediNet.Models;
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

        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var isUserUpdated = await _mediator.Send(new UpdateUserCommand(
               user.Id,
               user.UserName,
               user.Email,
               user.Password,
               user.Role,
               user.Position,
               user.Phone,
               user.Image));
            return Ok(isUserUpdated);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return Ok();
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

        //[HttpPost("refresh")]
        //public async Task<IActionResult> Refresh([FromBody] RefreshUserCommand command)
        //{
        //    return Ok(await _mediator.Send(command));
        //}
    }
}
