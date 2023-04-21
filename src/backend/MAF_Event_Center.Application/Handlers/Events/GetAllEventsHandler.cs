﻿using MAF_Event_Center.Application.Queries;
using MAF_Event_Center.Application.Services;
using MAF_Event_Center.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Handlers.Events
{
    public class GetAllEventsHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<Event>>
    {
        private readonly IRepository<Event> _repository;
        public GetAllEventsHandler(IRepository<Event> repository)
        {
            _repository = repository;
        }

        public  Task<IEnumerable<Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetAllAsync();
            return Task.FromResult(result.Result);
        }
    }
}
