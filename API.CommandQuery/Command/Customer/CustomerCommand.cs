using Order.Model;
using Order.Services.DTOs;
using Order.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CommandQuery.Command.Customer
{
    public class CustomerCommand : ICustomerCommand
    {
        private readonly ICustomerService _customerService;

        public CustomerCommand(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task AddCustomer(CustomerDTO customerDTO)
        {
            await _customerService.Add(customerDTO);    
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            bool res = await _customerService.Delete(id);
            return res;
        }

        public async Task<bool> UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            bool res = await _customerService.Update(id, customerDTO);
            return res;
        }
    }
}
