using API.CommandQuery.Command.Customer;
using API.CommandQuery.Query.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Services.DTOs;
using Order.Services.Interface;

namespace API.CQRS.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerCommand _customerCommand;
        private readonly ICustomerQuery _customerQuery;

        public CustomerController(ICustomerQuery customerQuery, ICustomerCommand customerCommand)
        {
            _customerQuery = customerQuery;
            _customerCommand = customerCommand;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> Get()
        {
            var customers = await _customerQuery.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetById(int id)
        {
            return await _customerQuery.GetCustomerById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerDTO  customer)
        {
            await _customerCommand.AddCustomer(customer);
            return Ok("Customer Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, CustomerDTO customer)
        {
            bool res = await _customerCommand.UpdateCustomer(id, customer);
            return res == true ? Ok("Customer Updated Successfully")
                : BadRequest("Please make correct request");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _customerCommand.DeleteCustomer(id);
            return res == true ? Ok("Customer Deleted Successfully")
                : NotFound("Customer Does not exist with " + id + " id");
        }

        [HttpGet("products/{id}")]
        public IActionResult GetProducts(int id)
        {
            var pd = _customerQuery.ProductByCustomer(id);
            return Ok(pd);
        }
    }
}
