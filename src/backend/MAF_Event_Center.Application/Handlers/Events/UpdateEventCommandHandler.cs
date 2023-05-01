using MAF_Event_Center.Application.Command.Events;
using MAF_Event_Center.Application.Services.Interfaces;
using MAF_Event_Center.Domain.DTOs.Events;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Handlers.Events
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, UpdateEventDTO>
    {
        private readonly IRepository<Event> _eventRepository;
        
        public UpdateEventCommandHandler(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<UpdateEventDTO> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var gameEvent = await _eventRepository.GetByIdAsync(request.Id);
            if(gameEvent == null)
            {
                throw new ArgumentNullException(nameof(gameEvent));
            }
            var result = new Event(request.Id, request.EventName, request.StartEvent,
                request.EndEvent, request.gameId, request.Status, gameEvent.HostLink, Guid.NewGuid(), gameEvent.GameName);

            await _eventRepository.UpdateAsync(result);

            return new UpdateEventDTO()
            {
                EndEvent = request.EndEvent,
                StartEvent = request.StartEvent,
                gameId = result.GameId,
                Status = result.Status,
                Id = request.Id,
                Name = result.Name,
            };
        }
    }
}
