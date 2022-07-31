using Api.Dto;
using Data.Contracts;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = _productRepository.TableNoTracking.ToList();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(RegisterProductDto model, CancellationToken cancellationToken)
        {
            var entity = new Product()
            {
                CategoryId = model.CategoryId,
                Code = model.Code,
                Name = model.Name,
            };
            await _productRepository.AddAsync(entity, cancellationToken);
            return Ok("Ok");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.GetByIdAsync(cancellationToken, id);
            if (entity == null)
                return NotFound();

            await _productRepository.DeleteAsync(entity, cancellationToken);
            return Ok("Ok");
        }

        [HttpPut]
        public async Task<IActionResult> EditProduct(int id,RegisterProductDto model, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.GetByIdAsync(cancellationToken, id);
            if (entity == null)
                return NotFound();

            entity.Name = model.Name;
            entity.Code = model.Code;
            entity.CategoryId = model.CategoryId;
            await _productRepository.UpdateAsync(entity, cancellationToken);
            return Ok("Ok");
        }
    }
}
