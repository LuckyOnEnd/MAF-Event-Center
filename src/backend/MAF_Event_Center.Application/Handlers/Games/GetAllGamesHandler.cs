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
    public class GetAllGamesHandler : IRequestHandler<GetAllGamesQuery, IEnumerable<Game>>
    {
        private readonly IRepository<Game> _repository;

        public GetAllGamesHandler(IRepository<Game> repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<Game>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAllAsync();
        }
    }
}
