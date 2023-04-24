using Order.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CommandQuery.Command.Customer
{
    public interface ICustomerCommand
    {
        public Task AddCustomer(CustomerDTO customerDTO);
        public Task<bool> UpdateCustomer(int id, CustomerDTO customerDTO);
        public Task<bool> DeleteCustomer(int id);

    }
}
