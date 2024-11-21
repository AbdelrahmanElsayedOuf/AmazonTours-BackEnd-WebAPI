using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Interfaces.Services.Base
{
    public interface IBaseService<T> where T : class, IEntity, new()
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllAsync(int pageNumber, int pageSize);
        Task<Guid> DeleteByIdAsync(Guid id);
        Task<Guid> AddAsync(T entity);
        Task<T> UpdateAsync(Guid id, T entity);
        Task<T> PatchAsync(Guid id, T entity);
        Task<IQueryable<T>> GetAllAsync(params Expression<Func<T, object>>[] IncludeProperties);
    }
}
