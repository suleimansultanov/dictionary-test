using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repositories
{
    public interface IRepository<T, in TU> : IDisposable where T : class
    {
        IQueryable<T> All { get; }

        T GetById(TU id);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        Task<T> GetByIdAsync(TU id);
        Task<T> AddAsync(T entity);
        Task<T> DeleteByIdAsync(TU id);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        IEnumerable<T> DeleteRange(IEnumerable<T> entities);
    }
}
