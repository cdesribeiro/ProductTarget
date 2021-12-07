using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Management.Domain.Interface.Repository
{
    public interface IBaseRepository<TEntity, TType>
    {
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TType> InsertAsync(TEntity entity);
        Task<TType> UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IList<TEntity> entity);
        Task DeleteAsync(TType id);
        Task DeleteAsync(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}
