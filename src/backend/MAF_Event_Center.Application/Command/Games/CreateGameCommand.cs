using MAF_Event_Center.Domain.DTOs.Event;
using MAF_Event_Center.Domain.DTOs.Games;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Command.Games
{
    public record CreateGameCommand(string Name, string ImageUrl) : IRequest<GameDTO>;
}
