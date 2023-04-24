using Order.Model;
using Order.Services.DTOs;
using Order.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CommandQuery.Query.Customer
{
    public class CustomerQuery : ICustomerQuery
    {
        private readonly ICustomerService _customerService;

        public CustomerQuery(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            var customers = await _customerService.GetCustomers();
            return customers;
        }

        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            return await _customerService.GetCustomerById(id);
        }

        public IEnumerable<ProductByCustomer> ProductByCustomer(int id)
        {
            var pd = _customerService.GetProductsCustomer(id);
            return pd;
        }
    }
}
