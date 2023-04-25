using MAF_Event_Center.Application.Command.Games;
using MAF_Event_Center.Application.Services.Interfaces;
using MAF_Event_Center.Domain.DTOs.Games;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Handlers.Games
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, GameDTO>
    {
        private readonly IRepository<Game> _gameRepository;
        public CreateGameCommandHandler(IRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<GameDTO> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetByNameAsync(request.Name);
            if (game != null)
                throw new ArgumentException();
            var createGame = new Game(request.Name, request.ImageUrl);
            await _gameRepository.AddAsync(createGame);

            var result = new GameDTO()
            {
                Name = request.Name,
                ImageUrl = request.ImageUrl,
            };
            return result;
        }
    }
}
