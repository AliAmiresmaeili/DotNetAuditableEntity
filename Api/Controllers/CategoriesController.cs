using Data.Contracts;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoryRepository.TableNoTracking.ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category model, CancellationToken cancellationToken)
        {
            await _categoryRepository.AddAsync(model, cancellationToken);
            return Ok("Ok");
        }

        [HttpPut]
        public async Task<IActionResult> EditCategory(Category model, CancellationToken cancellationToken)
        {
            var entity = await _categoryRepository.GetByIdAsync(cancellationToken, model.Id);
            if (entity == null)
                return NotFound();

            entity.Name = model.Name;
            await _categoryRepository.UpdateAsync(entity, cancellationToken);
            return Ok("Ok");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id, CancellationToken cancellationToken)
        {
            var entity = await _categoryRepository.GetByIdAsync(cancellationToken, id);
            if (entity == null)
                return NotFound();

            var isExist = _productRepository.IsExist(x => x.CategoryId == id);
            if (isExist)
                return BadRequest("cant delete,already used in products");

            await _categoryRepository.DeleteAsync(entity, cancellationToken);
            return Ok();
        }
    }
}
