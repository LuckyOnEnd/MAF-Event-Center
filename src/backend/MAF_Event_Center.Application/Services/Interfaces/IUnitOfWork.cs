using MAF_Event_Center.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Services.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Event> Events { get; }
        IRepository<AppUser> Users { get; }
        IRepository<Game> Games { get; }

        Task Commit();
    }
}
