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

namespace MAF_Event_Center.Application.Handlers.Events
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, CreateEventDTO>
    {
        private readonly IRepository<Event> _repository;
        private readonly IRepository<Game> _gameRepository;

        public CreateEventCommandHandler(IRepository<Event> repository, IRepository<Game> gameRepository)
        {
            _repository = repository;
            _gameRepository = gameRepository;
        }

        public Task<CreateEventDTO> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var gameId = _gameRepository.GetByIdAsync(request.gameId).Result;
            if(gameId == null)
            {
                throw new ArgumentNullException(nameof(gameId));
            }
            var entity = new Event(request.EventName, request.StartEvent, request.EndEvent, gameId, request.HostLink);
            _repository.AddAsync(entity);

            return Task.FromResult(new CreateEventDTO());
        }
    }
}
