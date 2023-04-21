using MAF_Event_Center.Application.Services;
using MAF_Event_Center.Domain.Entities;
using MAF_Event_Center.Infastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Infastructure.Repositories
{
    public class GameRepository : IRepository<Game>
    {
        private readonly AppDbContext _db;

        public GameRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(Game entity)
        {
            await _db.Games.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public Task DeleteById(Game entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Game> GetByIdAsync(Guid id)
        {
            return await _db.Games.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Game> GetByNameAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Game entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            var result = await _db.Games.ToListAsync();

            return result;
        }
    }
}