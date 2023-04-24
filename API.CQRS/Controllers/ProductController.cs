using API.CommandQuery.Command.Product;
using API.CommandQuery.Query.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Data.Interfaces;
using Order.Model;
using Order.Services.DTOs;
using Order.Services.Interface;

namespace API.CQRS.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductQuery _productQuery;
        private readonly IProductCommand _productCommand;

        public ProductController(IProductQuery productQuery, IProductCommand productCommand)
        {
            _productQuery = productQuery;
            _productCommand = productCommand;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productQuery.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var product = await _productQuery.GetProductById(id);
            if(product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDTO product)
        {
            if (product == null)
            {
                return BadRequest("Enter Valid Details");
            }
            await _productCommand.AddProduct(product);
            return Ok("Product Added successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDTO product)
        {
            bool res = await _productCommand.UpdateProduct(id, product);
            if (!res)
            {
                return NotFound("Product Not found");
            }
            return Ok("Product Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            bool res = await _productCommand.DeleteProduct(id);
            if(!res)
            {
                return NotFound("Product Not found");
            }
            return Ok("product Deleted Successfully");
        }
    }
}
