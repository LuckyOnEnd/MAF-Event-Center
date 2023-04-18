using MAF_Event_Center.Application.Command;
using MAF_Event_Center.Application.Services;
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
        private readonly IRepository<Event> _repository;
       
        public Task<CreateEventDTO> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = new Event(request.EventName,request.StartEvent,request.EndEvent,request.Game, request.HostLink);
            _repository.Add(entity);

            return Task.FromResult(new CreateEventDTO());
        }
    }
}
