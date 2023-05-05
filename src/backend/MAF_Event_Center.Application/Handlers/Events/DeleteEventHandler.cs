using MAF_Event_Center.Application.Queries.Events;
using MAF_Event_Center.Application.Services.Interfaces;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Handlers.Events
{
    public class DeleteEventHandler : IRequestHandler<DeleteEventQuery, Event>
    {
        private readonly IRepository<Event> _repository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DeleteEventHandler(IRepository<Event> repository, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor) 
        {
            _repository = repository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Event> Handle(DeleteEventQuery request, CancellationToken cancellationToken)
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Name == userName);

            var Event = await _repository.GetByIdAsync(request.Id);


            await _repository.DeleteById(Event);

            return Event;
        }   
    }
}
