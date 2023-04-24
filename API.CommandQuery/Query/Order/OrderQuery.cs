using Order.Services.DTOs;
using Order.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CommandQuery.Query.Order
{
    public class OrderQuery : IOrderQuery
    {
        private readonly IOrderService _orderService;

        public OrderQuery(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<OrdersDTO> GetOrderById(int id)
        {
            return await _orderService.GetOrderById(id);
        }

        public async Task<IEnumerable<OrdersDTO>> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            return orders;
        }
    }
}
