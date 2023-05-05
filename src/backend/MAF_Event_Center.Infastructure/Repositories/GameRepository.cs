using MAF_Event_Center.Application.Services.Interfaces;
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
        private readonly ApplicationDbContext _db;

        public GameRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(Game entity)
        {
            await _db.Games.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteById(Game entity)
        {
            _db.Games.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Game> GetByIdAsync(Guid id)
        {
            return await _db.Games.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Game> GetByNameAsync(string name)
        {
            return await _db.Games.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            var result = await _db.Games.ToListAsync();

            return result;
        }

        public Task UpdateAsync(Game entity)
        {
            throw new NotImplementedException();
        }
    }
}