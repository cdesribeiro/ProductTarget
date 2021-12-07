using Management.Domain.Entities;
using Management.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Domain.Interface.Repository
{
    public interface IProductRepository
    {
        Task<Product> InsertAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task DeleteAsync(long id);
        Task<Product> GetProductById(long id);
        Task<IList<Product>> GetAllProducts();
    }
}
