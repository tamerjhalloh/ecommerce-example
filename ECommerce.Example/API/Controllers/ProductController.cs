using API.DTOs.Product;
using API.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductService _service;

        public ProductController(ILogger<ProductController> logger, ProductService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetProductRequest request)
        {
            var products = await _service.SearchAsync(request);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProductRequest request)
        {
            var product = await _service.AddNewAsync(request);
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductRequest request)
        {
            var product = await _service.UpdateAsync(request);
            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProductRequest request)
        {
            var product = await _service.DeleteAsync(request);
            return Ok(product);
        } 
       
    }
}
