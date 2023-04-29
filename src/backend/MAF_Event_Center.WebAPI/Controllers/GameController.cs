using MAF_Event_Center.Application.Command.Games;
using MAF_Event_Center.Application.Queries.Events;
using MAF_Event_Center.Application.Queries.Games;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MAF_Event_Center.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetGames([FromQuery] GetAllGamesQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreateGame(CreateGameCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
