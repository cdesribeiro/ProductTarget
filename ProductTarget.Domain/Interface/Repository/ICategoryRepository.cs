using Management.Domain.Entities;
using Management.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Domain.Interface.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> InsertAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task DeleteAsync(long id);
        Task<Category> GetCategoryById(long id);
        Task<IList<Category>> GetAllCategories();
    }
}
