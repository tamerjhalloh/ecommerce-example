using API.DTOs.Customer;
using API.Services.Customer;
using API.Services.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {


        private readonly ILogger<CustomerController> _logger;
        private readonly CustomerService _service;
        private readonly OrderService _orderService;

        public CustomerController(ILogger<CustomerController> logger, CustomerService service, OrderService orderService)
        {
            _logger = logger;
            _service = service;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCustomerRequest request)
        {
            var customers = await _service.SearchAsync(request);
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCustomerRequest request)
        {
            var customer = await _service.AddNewAsync(request);
            return Ok(customer);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerRequest request)
        {
            var customer = await _service.UpdateAsync(request);
            return Ok(customer);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerRequest request)
        {
            var customer = await _service.DeleteAsync(request);
            return Ok(customer);
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetCustomerOrders([FromQuery] GetCustomerOrdersRequest request)
        {
            var orders = await _orderService.SearchAsync(request);
            return Ok(orders);
        }
    }
}
