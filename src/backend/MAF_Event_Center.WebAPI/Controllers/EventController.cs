using MAF_Event_Center.Application.Command.Event;
using MAF_Event_Center.Application.Command.Events;
using MAF_Event_Center.Application.Queries.Events;
using MAF_Event_Center.Domain.DTOs.Event;
using MAF_Event_Center.Domain.DTOs.Events;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MAF_Event_Center.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class EventController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;
        public EventController(IMediator mediator, UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetEvents([FromQuery] GetAllEventsQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [AllowAnonymous]
        [HttpGet("GetEventById")]
        public async Task<IActionResult> GetEvent([FromQuery] GetEventByIdQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("CreateEvent")]
        public async Task<IActionResult> CreateEvent(CreateEventCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("EditEvent")]
        public async Task<ActionResult> UpdateEvent(UpdateEventCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("JoinToEvent")]
        public async Task<ActionResult> JoinToEvent(JoinToEventCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("GetAllUserInEvent")]
        public async Task<IActionResult> GetUserInEvent([FromQuery] GetUserEventsQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteEvent")]
        public async Task<ActionResult> DeleteEvent([FromQuery] DeleteEventQuery commnad)
        {
            var result = await _mediator.Send(commnad);
            return Ok(result);
        }
    }
}
