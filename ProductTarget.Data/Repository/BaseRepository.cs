using Management.Data.Context;
using Management.Domain.Entities;
using Management.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Management.Data.Repository
{
    public abstract class BaseRepository<TEntity, TType> : IBaseRepository<TEntity, TType> where TEntity : BaseEntity<TType>, new()
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync();
        }

        public virtual async Task<TType> InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity.Id;
        }

        public virtual async Task<TType> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity.Id;
        }

        public virtual async Task UpdateRangeAsync(IList<TEntity> entity)
        {
            _dbSet.UpdateRange(entity);
        }

        public virtual async Task DeleteAsync(TType id)
        {
            _dbSet.Remove(new TEntity { Id = id });
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context
                .SaveChangesAsync();
        }
    }
}
