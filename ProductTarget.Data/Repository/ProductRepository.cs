using Management.Data.Context;
using Management.Domain.Entities;
using Management.Domain.Interface.Repository;
using Management.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ProductTarget.Domain.ViewModels;

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

        public IList<ProductGridViewModel> GetProductsGrid(string search, string sort, string order, int offset, int limit)
        {
            var query = from product in _dbSet.AsNoTracking()
                        select new ProductGridViewModel
                        {
                            Id = product.Id,
                            Description = product.Description,
                            ShortDescription = product.ShortDescription,
                            Quantity = product.Quantity,
                            Value = product.Value,
                            TotalValue = product.Quantity * product.Value,
                            RegistrationDate = product.RegisterDate.ToString("yyyy-MM-dd HH-mm-ss")
                        };

            if (!string.IsNullOrEmpty(search))
                query = query.Where(desc => desc.Description.Contains(search) || desc.ShortDescription.Contains(search));

            if (limit != 0)
                query = query
                    .Skip(offset)
                    .Take(limit);

            return query.ToList();
        }

        public ProductViewModel GetProductEdit(long id)
        {
            var query = from product in _dbSet.AsNoTracking()
                        where product.Id == id
                        select new ProductViewModel
                        {
                            Id = id,
                            Active = product.Active,
                            Description = product.Description,
                            ShortDescription = product.ShortDescription,
                            Quantity = product.Quantity,
                            Value = product.Value
                        };

            return query.FirstOrDefault();
        }
    }
}
