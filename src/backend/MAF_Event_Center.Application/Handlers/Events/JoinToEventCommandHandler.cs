using MAF_Event_Center.Application.Command.Events;
using MAF_Event_Center.Application.Queries.Events;
using MAF_Event_Center.Application.Services.Interfaces;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JoinToEventCommandHandler(IRepository<UserEvent> userEventRepository, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _userEventRepository = userEventRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<UserEvent> Handle(JoinToEventCommand request, CancellationToken cancellationToken)
        {
            var user = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var userId = _userManager.FindByNameAsync(user).Result.Id;
            var userEvent = new UserEvent(Guid.Parse(userId), request.eventId);
            var userEventExits = _userEventRepository.GetAllAsync().Result.Where(x => x.Id == Guid.Parse(userId));

            if (userEventExits == null)
                throw new ArgumentException("User already join to this event");
            await _userEventRepository.AddAsync(userEvent);

            return userEvent;
        }
    }
}
