﻿using MAF_Event_Center.Application.Command.User;
using MAF_Event_Center.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace MAF_Event_Center.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetUsers([FromQuery] GetAllUsersQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("GetById")]
        public async Task<ActionResult> GetUserById([FromQuery] GetUserByIdQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("GetByName")]
        public async Task<ActionResult> GetUserByName([FromQuery] GetUserByNameQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("GetUserRole")]
        public async Task<ActionResult> GetUserRole([FromQuery] GetUserRoleQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public ActionResult CreateUser(CreateUserCommand command)
        {
            var result = _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateUser(UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("CurrentUser")]
        public async Task<ActionResult> GetCurrentUser([FromQuery] GetCurrentUserQuery command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
