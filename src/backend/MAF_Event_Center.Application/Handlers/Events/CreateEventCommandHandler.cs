using MAF_Event_Center.Application.Command.Event;
using MAF_Event_Center.Application.Services.Interfaces;
using MAF_Event_Center.Domain.DTOs.Event;
using MAF_Event_Center.Domain.Entities;
using MAF_Event_Center.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Handlers.Events
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, CreateEventDTO>
    {
        private readonly IRepository<Event> _repository;
        private readonly IRepository<Game> _gameRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateEventCommandHandler(IRepository<Event> repository, IRepository<Game> gameRepository, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _gameRepository = gameRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateEventDTO> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var userName = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Name == userName);
            var game = await _gameRepository.GetByIdAsync(request.gameId);
            if (game == null) throw new ArgumentNullException();
            var entity = new Event(new Guid(),request.EventName, request.StartEvent, request.EndEvent, 
                request.gameId, EventStatus.Acitve, request.HostLink, Guid.Parse(user.Id));
            await _repository.AddAsync(entity);

            var result = new CreateEventDTO()
            {
                gameId = (Guid)game.Id,
                Name = request.EventName,
                StartEvent = request.StartEvent,
                EndEvent = request.EndEvent,
            };
            return result;
        }
    }
}
