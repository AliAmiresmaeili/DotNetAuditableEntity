using Data.Contracts;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
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
        public async Task<IActionResult> AddProduct(Product model, CancellationToken cancellationToken)
        {
            await _productRepository.AddAsync(model, cancellationToken);
            return Ok("Ok");
        }
    }
}
