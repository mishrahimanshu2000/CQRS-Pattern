using Order.Services.DTOs;
using Order.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CommandQuery.Command.Product
{
    public class ProductCommand : IProductCommand
    {
        private readonly IProductService _productService;

        public ProductCommand(IProductService productService)
        {
            _productService = productService;
        }

        public async Task AddProduct(ProductDTO product)
        {
            await _productService.Add(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            bool res = await _productService.Delete(id);
            return res;
        }

        public async Task<bool> UpdateProduct(int id, ProductDTO product)
        {
            bool res = await _productService.Update(id, product);
            return res;
        }
    }
}
