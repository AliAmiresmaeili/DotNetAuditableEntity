using Data.Contracts;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {


        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        [HttpGet]
        public IActionResult GetCategories()
        {
            var result = _categoryRepository.TableNoTracking.ToList();
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

            await _categoryRepository.DeleteAsync(entity, cancellationToken);
            return Ok("Ok");
        }
    }
}
