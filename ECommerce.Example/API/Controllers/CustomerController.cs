using API.DTOs.Customer;
using API.Services.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
         

        private readonly ILogger<CustomerController> _logger;
        private readonly CustomerService _service;

        public CustomerController(ILogger<CustomerController> logger, CustomerService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCustomerRequest request)
        {
            var custoemrs = await _service.SearchAsync(request);
            return Ok(custoemrs);
        }

    }
}
