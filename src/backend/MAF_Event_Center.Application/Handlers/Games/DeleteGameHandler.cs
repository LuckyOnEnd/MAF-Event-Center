using MAF_Event_Center.Application.Handlers.Events;
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
    public class DeleteGameHandler : IRequestHandler<DeleteGameQuery, Game>
    {
        private readonly IRepository<Game> _gameRepository;

        public DeleteGameHandler(IRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public async Task<Game> Handle(DeleteGameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var game = await _gameRepository.GetByIdAsync(request.Id);
                await _gameRepository.DeleteById(game);

                return game;
            }
            catch
            {
                throw new ArgumentException("Something went wrong");
            }
        }
    }
}
