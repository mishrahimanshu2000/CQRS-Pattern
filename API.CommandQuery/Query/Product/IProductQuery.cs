using Order.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CommandQuery.Query.Product
{
    public interface IProductQuery
    {
        public Task<IEnumerable<ProductDTO>> GetAllProducts();

        public Task<ProductDTO> GetProductById(int id);
    }
}
