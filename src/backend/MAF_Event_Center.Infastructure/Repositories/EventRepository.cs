using MAF_Event_Center.Application.Services;
using MAF_Event_Center.Domain.Entities;
using MAF_Event_Center.Infastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Infastructure.Repositories
{
    public class EventRepository : IRepository<Event>
    {
        public readonly AppDbContext _dbContext;

        public EventRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Event entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(Event entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            return _dbContext.Events;
        }

        public Event GetById(Guid id)
        {
            return _dbContext.Events.FirstOrDefault(x => x.Id == id);
        }

        public Event GetByName(string name)
        {
            return _dbContext.Events.FirstOrDefault(x => x.Name == name);
        }

        public void Update(Event entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
