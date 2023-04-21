using MAF_Event_Center.Application.Command;
using MAF_Event_Center.Application.Queries;
using MAF_Event_Center.Domain.DTOs.Event;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MAF_Event_Center.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : Controller
    {
        private readonly IMediator _mediator;
        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetEvents([FromQuery] GetAllEventsQuery command)
        {
            var result = _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetEventById")]
        public async Task<IActionResult> GetEvent([FromQuery] GetEventByIdQuery command)
        {
            var result = _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEvent(CreateEventCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
