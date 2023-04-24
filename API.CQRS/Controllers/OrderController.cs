using API.CommandQuery.Command.Order;
using API.CommandQuery.Query.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Model;
using Order.Services.DTOs;
using Order.Services.Interface;

namespace API.CQRS.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderQuery _orderQuery;
        private readonly IOrderCommand _orderCommand;

        public OrderController(IOrderQuery orderQuery, IOrderCommand orderCommand)
        {
            _orderQuery = orderQuery;
            _orderCommand = orderCommand;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersDTO>>> Get()
        {
            var orderDetails = await _orderQuery.GetOrders();
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersDTO>> GetById(int id)
        {
            return await _orderQuery.GetOrderById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrdersDTO order)
        {
            await _orderCommand.AddOrder(order);
            return Ok("Order Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, OrdersDTO order)
        {
            bool res = await _orderCommand.UpdateOrder(id, order);
            return res == true ? Ok("Order Updated Successfully")
                : BadRequest("please make correct request");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _orderCommand.DeleteOrder(id);
            return res == true ? Ok("Order Deleted Successfully")
                : NotFound("Order Does not exist with " + id + " id");
        }
    }
}
