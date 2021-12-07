using Management.Domain.Entities;
using Management.Domain.Interface.Repository;
using Management.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.BusinessRule.Rules
{
    public class ProductRule
    {
        private readonly IProductRepository _productRepository;
        public ProductRule(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> SaveOrUpdate(ProductViewModel model)
        {
            Product product = null;
            if (model == null)
                throw new ArgumentNullException();

            if (model.Id == 0)
            {
                product = new Product()
                {
                    Description = model.Description,
                    ShortDescription = model.ShortDescription,
                    Active = model.Active,
                    Quantity = model.Quantity,
                    Value = model.Value,
                    RegisterDate = DateTime.Now,
                    CategoryId = model.CategoryId != 0 ? model.CategoryId : (long?)null
                };

                product = await _productRepository.InsertAsync(product);
            }
            else
            {
                product = await _productRepository.GetProductById(model.Id);
                if (product == null)
                    throw new KeyNotFoundException();

                product.Description = model.Description;
                product.ShortDescription = model.ShortDescription;
                product.Active = model.Active;
                product.Quantity = model.Quantity;
                product.Value = model.Value;
                product.CategoryId = model.CategoryId != 0 ? model.CategoryId : (long?)null;

                await _productRepository.UpdateAsync(product);
            }

            return product;
        }
    }
}
