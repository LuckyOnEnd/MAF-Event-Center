using MAF_Event_Center.Application.Services.Interfaces;
using MAF_Event_Center.Domain.Entities;
using MAF_Event_Center.Infastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Infastructure.Repositories
{
    public class UserEventRepository : IRepository<UserEvent>
    {
        private readonly ApplicationDbContext _db;
        public UserEventRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(UserEvent entity)
        {
            await _db.UserEvents.AddAsync(entity);
        }

        public Task DeleteById(UserEvent entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserEvent>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserEvent> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserEvent> GetByNameAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserEvent entity)
        {
            throw new NotImplementedException();
        }
    }
}
