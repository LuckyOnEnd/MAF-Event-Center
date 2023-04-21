using MAF_Event_Center.Domain.DTOs.Event;
using MAF_Event_Center.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Application.Services
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByNameAsync(string Id);
        Task AddAsync(T entity);
        Task Update(T entity);
        Task DeleteById(T entity);
    }
}
