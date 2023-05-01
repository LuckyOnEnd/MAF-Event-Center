using MAF_Event_Center.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Command.Events
{
    public record JoinToEventCommand(Guid userId, Guid eventId) : IRequest<UserEvent>
    { 
    }
}
