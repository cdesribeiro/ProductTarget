using Management.BusinessRule.Rules;
using Management.Data.Context;
using Management.Domain.Interface.Repository;
using Management.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ProductTarget.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductRule _productRule;
        public ProductController(AppDbContext context, IProductRepository productRepository, ProductRule productRule) : base(context)
        {
            _productRepository = productRepository;
            _productRule = productRule;
        }

        [HttpPost]
        [HttpPut]
        public async Task<IActionResult> Create([FromBody] ProductViewModel model)
        {
            try
            {
                var product = await _productRule.SaveOrUpdate(model);
                return Created("Get", product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] long id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] long id)
        {
            try
            {
                await _productRepository.DeleteAsync(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProductsGridList")]
        public async Task<IActionResult> GetProductsGridList(string search, string sort, string order, int offset, int limit)
        {
            return Ok();
        }
    }
}
