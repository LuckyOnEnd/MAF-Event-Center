using MAF_Event_Center.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Queries
{
    public class GetAllEventsQuery : IRequest<List<Event>>
    {
    }
}
