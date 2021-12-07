using Management.Domain.Entities;
using Management.Domain.Interface.Repository;
using Management.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.BusinessRule.Rules
{
    public class CategoryRules
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> SaveOrUpdate(CategoryViewModel model)
        {
            Category category = null;
            if (model == null)
                throw new ArgumentNullException("Categoria nula");

            if (model.Id == 0)
            {
                category = new Category()
                {
                    Code = model.Code,
                    Description = model.Description
                };

                category = await _categoryRepository.InsertAsync(category);
            }
            else
            {
                category = await _categoryRepository.GetCategoryById(model.Id);
                if(category == null)
                    throw new KeyNotFoundException();   

                category.Description = model.Description;
                category.Code = model.Code;

                await _categoryRepository.UpdateAsync(category);
            }

            return category;
        }
    }
}
