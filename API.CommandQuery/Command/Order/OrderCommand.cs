using Order.Model;
using Order.Services.DTOs;
using Order.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CommandQuery.Command.Order
{
    public class OrderCommand : IOrderCommand
    {
        private readonly IOrderService _orderService;

        public OrderCommand(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task AddOrder(OrdersDTO ordersDTO)
        {
            await _orderService.Add(ordersDTO);
        }

        public async Task<bool> DeleteOrder(int id)
        {
            bool res = await _orderService.Delete(id);
            return res;
        }

        public async Task<bool> UpdateOrder(int id, OrdersDTO ordersDTO)
        {
            bool res = await _orderService.Update(id, ordersDTO);
            return res;        }
    }
}
