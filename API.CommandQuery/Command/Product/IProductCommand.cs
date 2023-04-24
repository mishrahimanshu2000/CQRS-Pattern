using Order.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CommandQuery.Command.Product
{
    public interface IProductCommand
    {
        public Task AddProduct(ProductDTO product);

        public Task<bool> DeleteProduct(int id);

        public Task<bool> UpdateProduct(int id, ProductDTO product);
    }
}
