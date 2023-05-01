using MAF_Event_Center.Domain.DTOs.Events;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Queries.Events
{
    public class GetUserEventsQuery: IRequest<List<UserEventDTO>>
    {
        public Guid EventId { get; set; }
    }
}
