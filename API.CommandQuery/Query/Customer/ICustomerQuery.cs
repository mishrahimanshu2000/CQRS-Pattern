using Order.Model;
using Order.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CommandQuery.Query.Customer
{
    public interface ICustomerQuery
    {
        public Task<CustomerDTO> GetCustomerById(int id);
        public Task<IEnumerable<CustomerDTO>> GetAllCustomers();
        public IEnumerable<ProductByCustomer> ProductByCustomer(int id);
    }
}
