using Order.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CommandQuery.Query.Order
{
    public interface IOrderQuery
    {
        public Task<IEnumerable<OrdersDTO>> GetOrders();

        public Task<OrdersDTO> GetOrderById(int id);
    }
}
