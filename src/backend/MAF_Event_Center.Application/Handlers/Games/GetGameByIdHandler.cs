using MAF_Event_Center.Application.Queries.Events;
using MAF_Event_Center.Application.Queries.Games;
using MAF_Event_Center.Application.Services.Interfaces;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Handlers.Games
{
    public class GetGameByIdHandler : IRequestHandler<GetGameByIdQuery, Game>
    {
        private readonly IRepository<Game> _gameRepository;
        public GetGameByIdHandler(IRepository<Game> gameRepository) 
        {
            _gameRepository = gameRepository;
        }

        public Task<Game> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            var game = _gameRepository.GetByIdAsync(request.Id);

            return game;
        }
    }
}
