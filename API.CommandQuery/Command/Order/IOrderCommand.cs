using Order.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CommandQuery.Command.Order
{
    public interface IOrderCommand
    {
        public Task AddOrder(OrdersDTO ordersDTO);

        public Task<bool> DeleteOrder(int id);

        public Task<bool> UpdateOrder(int id, OrdersDTO ordersDTO);
    }
}
