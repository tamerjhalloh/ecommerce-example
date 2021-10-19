using API.DTOs.Order;
using API.Services.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    { 
         
        private readonly OrderService _service;

        public OrderController( OrderService service)
        { 
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetOrderRequest request)
        {
            var orders = await _service.SearchAsync(request);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddOrderRequest request)
        {
            var order = await _service.AddNewAsync(request);
            return Ok(order);
        }

         
    }
}
