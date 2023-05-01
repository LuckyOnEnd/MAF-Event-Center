﻿using MAF_Event_Center.Domain.DTOs.Event;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Command.Event
{
    public record CreateEventCommand(string eventName, DateTime StartEvent, DateTime EndEvent,
       Guid gameId) : IRequest<CreateEventDTO>;
}
