using MAF_Event_Center.Application.Services;
using MAF_Event_Center.Domain.Entities;
using MAF_Event_Center.Infastructure.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(Event entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteById(Event entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            var result = await _dbContext.Events.ToListAsync();
            return result;
        }
        public async Task<Event> GetByIdAsync(Guid id)
        {
            return await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Event> GetByNameAsync(string name)
        {
            return await _dbContext.Events.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task Update(Event entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}