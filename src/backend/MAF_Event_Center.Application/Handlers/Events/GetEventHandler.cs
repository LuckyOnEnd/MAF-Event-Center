using MAF_Event_Center.Application.Queries;
using MAF_Event_Center.Application.Services;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Handlers.Events
{
    public class GetEventHandler : IRequestHandler<GetEventByIdQuery, Event>
    {
        private readonly IRepository<Event> _eventRepository;
        public GetEventHandler(IRepository<Event> repository) 
        {
            _eventRepository = repository;
        }

        public async Task<Event> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _eventRepository.GetByIdAsync(request.Id);
            return result;
        }
    }
}
