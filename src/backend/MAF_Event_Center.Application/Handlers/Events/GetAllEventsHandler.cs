using MAF_Event_Center.Application.Queries;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Handlers.Events
{
    public class GetAllEventsHandler : IRequestHandler<GetAllEventsQuery, List<Event>>
    {
        public List<Event> events = new List<Event>()
        {
            new Event("First event",DateTime.Now, DateTime.Now.AddDays(1), "asd.com")
        };
        public GetAllEventsHandler()
        {
        }

        public Task<List<Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(events);
        }
    }
}
