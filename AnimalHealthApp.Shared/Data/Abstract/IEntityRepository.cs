using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using AnimalHealthApp.Shared.Entities.Abstract;

namespace AnimalHealthApp.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T,object>>[] includeProperties); // var user = repository.GetAsync(k=>k.Id==15);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate=null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> prediacte); // Is there such a record?
        Task<int> CountAsync(Expression<Func<T, bool>> prediacte = null);
    }
}
