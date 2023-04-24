using Order.Services.DTOs;
using Order.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CommandQuery.Query.Product
{
    public class ProductQuery : IProductQuery
    {
        private readonly IProductService _productService;

        public ProductQuery(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = await _productService.GetProducts();
            return products;
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            return await _productService.GetProductById(id);
        }
    }
}
