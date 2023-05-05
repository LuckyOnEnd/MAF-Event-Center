using MAF_Event_Center.Application.Queries.Events;
using MAF_Event_Center.Application.Services.Interfaces;
using MAF_Event_Center.Domain.DTOs.Events;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Handlers.Events
{
    public class GetUserEventsHandler : IRequestHandler<GetUserEventsQuery, List<UserEventDTO>>
    {
        private readonly IRepository<UserEvent> _userEventsRepository;
        private readonly IRepository<Event> _eventRepository;
        private readonly UserManager<AppUser> _userManager;
        public GetUserEventsHandler(IRepository<UserEvent> userEventsRepository, IRepository<Event> eventRepository, UserManager<AppUser> userManager) 
        {
            _userEventsRepository = userEventsRepository;
            _eventRepository = eventRepository;
            _userManager = userManager;
        }

        public async Task<List<UserEventDTO>> Handle(GetUserEventsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userEvents = await _userEventsRepository.GetAllAsync();

                var result = new List<UserEventDTO>();

                foreach (var userEvent in userEvents)
                {
                    var appEvent = await _eventRepository.GetByIdAsync(userEvent.EventId);
                    if (appEvent == null)
                        break;
                    var userName = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userEvent.Id.ToString());
                    result.Add(new UserEventDTO()
                    {
                        EventName = appEvent.Name,
                        UserName = userName.UserName,
                    });
                }

                return result.ToList();
            }
            catch
            {
                throw new ArgumentException("Somthing is went wrong");
            }
            
        }
    }
}
