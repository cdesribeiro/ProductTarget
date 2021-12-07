using Management.Data.Context;
using Management.Domain.Entities;
using Management.Domain.Interface.Repository;
using Management.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Management.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category, long>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<Category> InsertAsync(Category category)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                category.Id = await base.InsertAsync(category);
                await base.SaveChangesAsync();
                await transaction.CommitAsync();
                return category;
            }
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                await base.UpdateAsync(category);
                await base.SaveChangesAsync();
                await transaction.CommitAsync();
                return category;
            }
        }

        public async Task DeleteAsync(long id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                await base.DeleteAsync(id);
                await base.SaveChangesAsync();
                await transaction.CommitAsync();
            }
        }

        public async Task<Category> GetCategoryById(long id)
        {
            var query = from category in _dbSet.AsNoTracking()
                        where category.Id == id
                        select category;

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IList<Category>> GetAllCategories()
        {
            var query = from category in _dbSet.AsNoTracking()
                        select category;


            return await query.ToListAsync();
        }
    }
}