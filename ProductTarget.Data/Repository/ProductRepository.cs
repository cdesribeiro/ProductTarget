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
    public class ProductRepository : BaseRepository<Product, long>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> InsertAsync(Product product)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                product.Id = await base.InsertAsync(product);
                await base.SaveChangesAsync();
                await transaction.CommitAsync();
                return product;
            }
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                await base.UpdateAsync(product);
                await base.SaveChangesAsync();
                await transaction.CommitAsync();
                return product;
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

        public async Task<Product> GetProductById(long id)
        {
            var query = from product in _dbSet.AsNoTracking()
                        where product.Id == id
                        select product;

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IList<Product>> GetAllProducts()
        {
            var query = from product in _dbSet.AsNoTracking()
                        select product;


            return await query.ToListAsync();
        }
    }
}
