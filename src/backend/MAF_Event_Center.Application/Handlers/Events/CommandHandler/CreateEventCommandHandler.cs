using MAF_Event_Center.Application.Command;
using MAF_Event_Center.Domain.DTOs.Event;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Handlers.Events.CommandHandler
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, CreateEventDTO>
    {
        public List<Event> events = new List<Event>()
        {
            new Event("First event",DateTime.Now, DateTime.Now.AddDays(1), new Game("CS:GO", "https/:google.com"),"asd.com")
        };
        public Task<CreateEventDTO> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            events.Add(new Event("First event", DateTime.Now, DateTime.Now.AddDays(1), new Game("CS:GO", "https/:google.com"), "asd.com"));

            return Task.FromResult(new CreateEventDTO());
        }
    }
}
