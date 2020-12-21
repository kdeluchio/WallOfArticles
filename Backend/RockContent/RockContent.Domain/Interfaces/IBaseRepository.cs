using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RockContent.Domain.Models;

namespace RockContent.Domain.Interfaces
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        Task<T> InsertAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<bool> DeleteAsync(Guid id);
        Task<T> GetByIdAsync(Guid id);
        Task<IQueryable<T>> GetByAllAsync();
    }
}