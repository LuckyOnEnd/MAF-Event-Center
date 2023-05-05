using MAF_Event_Center.Domain.DTOs.AppUser;
using MAF_Event_Center.Domain.DTOs.Event;
using MAF_Event_Center.Domain.DTOs.Events;
using MAF_Event_Center.Domain.Entities;
using MAF_Event_Center.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Command.Events
{
    public record UpdateEventCommand(Guid Id ,string EventName, DateTime StartEvent, DateTime EndEvent,
       Guid gameId, string Description) : IRequest<UpdateEventDTO>;
}
