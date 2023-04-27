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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetEvents([FromQuery] GetAllEventsQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetEventById")]
        public async Task<IActionResult> GetEvent([FromQuery] GetEventByIdQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("CreateEvent")]
        public async Task<ActionResult> CreateEvent(CreateEventCommand command)
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

        [HttpPost]
        public async Task<ActionResult> JoinToEvent(JoinToEventCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
