using Data.Contracts;
using Domain;
using Microsoft.AspNetCore.Http;
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


        [HttpGet(Name = "GetCategories")]
        public IActionResult GetCategories()
        {
            var result = _categoryRepository.TableNoTracking.ToList();
            return Ok(result);
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<IActionResult> AddCategory(Category model, CancellationToken cancellationToken)
        {
            await _categoryRepository.AddAsync(model, cancellationToken);
            return Ok("Ok");
        }
    }
}
