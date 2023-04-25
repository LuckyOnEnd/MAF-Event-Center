using MAF_Event_Center.Application.Command.Events;
using MAF_Event_Center.Application.Services.Interfaces;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Handlers.Events
{
    public class JoinToEventCommandHandler : IRequestHandler<JoinToEventCommand, UserEvent>
    {
        private readonly IRepository<UserEvent> _userEventRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JoinToEventCommandHandler(IRepository<UserEvent> userEventRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userEventRepository = userEventRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserEvent> Handle(JoinToEventCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);   
            var userEvent = new UserEvent(Guid.Parse(userId), request.eventId);

            await _userEventRepository.AddAsync(userEvent);

            return userEvent;
        }
    }
}
