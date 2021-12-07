using Management.BusinessRule.Rules;
using Management.Data.Context;
using Management.Domain.Interface.Repository;
using Management.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ProductTarget.API.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryRules _categoryRules;
        public CategoryController(AppDbContext context, ICategoryRepository categoryRepository, CategoryRules categoryRules) : base(context)
        {
            _categoryRepository = categoryRepository;
            _categoryRules = categoryRules;
        }

        [HttpPost]
        [HttpPut]
        public async Task<IActionResult> Create([FromBody] CategoryViewModel model)
        {

            try
            {
                var category = await _categoryRules.SaveOrUpdate(model);
                return Created("Get", category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _categoryRepository.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
