using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet(Name = "GetCategories")]
        public IActionResult Get()
        {
            return Ok("Ok");
        }
    }
}
