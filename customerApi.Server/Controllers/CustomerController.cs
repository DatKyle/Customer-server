using CarApi.Domain.Services.Customer;
using CarApi.Models;
using customerApi.Server.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarApi.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService,
            ILogger<CustomerController> logger)
        {
            _logger = logger;
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<CustomerModel> Get()
        {
            return _customerService.GetAll();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustomerModel? Get(int id)
        {
            return _customerService.GetById(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public Results<BadRequest<string>, Ok<int>> Post([FromBody] CustomerModel customer)
        {
            try
            {
                var customerId = _customerService.Create(customer);
                return TypedResults.Ok(customerId);
            }
            catch (ArgumentException argError)
            {
                return TypedResults.BadRequest(argError.Message);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public Results<BadRequest<string>, Ok> Put(int id, [FromBody] CustomerModel customer)
        {

            try
            {
                customer.Id = id;
                _customerService.Update(customer);
                return TypedResults.Ok();
            }
            catch (ArgumentException argError)
            {
                return TypedResults.BadRequest(argError.Message);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customerService.Delte(id);
        }
    }
}
