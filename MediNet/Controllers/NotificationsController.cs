using MediatR;
using MediNet.Commands.Notifications;
using MediNet.Queries.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediNet.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotificationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-notification")]
        public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("get-list-notification")]
        public async Task<IActionResult> GetNotificationListByUserId(int userId)
        {
            var listNoti = await _mediator.Send(new GetNotificationListByUserIdQuery(userId));
            return Ok(listNoti);
        }

        [HttpGet("get-list-unseen-notification")]
        public async Task<IActionResult> GetUnSeenNotificationList(int userId)
        {
            var listUnSeenNoti = await _mediator.Send(new GetUnSeenNotificationListQuery(userId));
            return Ok(listUnSeenNoti);
        }

        [HttpPatch("view-unseen-notification")]
        public async Task<IActionResult> View(int userId)
        {
            return Ok(await _mediator.Send(new ViewNotificationCommand(userId)));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Read(int id, int userId)
        {
            return Ok(await _mediator.Send(new ReadNotificationCommand(id, userId)));
        }
    }
}
