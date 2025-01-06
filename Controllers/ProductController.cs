using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductWebAPI.Data;
using ProductWebAPI.Models;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task <ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null)
                return NotFound("product not found");
            
            return Ok(product);
        }

        [HttpPost]
        public async Task <ActionResult<Product>> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPut]
        public async Task <ActionResult<Product>> UpdateProduct(Product product)
        {
            var dbProduct = await _context.Products.FindAsync(product.Id);
            if (dbProduct is null)
                return NotFound("Product Not Found");

            dbProduct.ProductName = product.ProductName;
            dbProduct.ProductDescription = product.ProductDescription;
            dbProduct.ProductType = product.ProductType;    
            dbProduct.Quntity = product.Quntity;
            dbProduct.ProductCategory = product.ProductCategory;

            await _context.SaveChangesAsync();

            return Ok(dbProduct);

        }

        [HttpDelete]

        public async Task <ActionResult<Product>> RemoveProduct(Product product)
        {
            var dbProduct = await _context.Products.FindAsync(product.Id);

            if (dbProduct is null)
                return NotFound("Product Not Found");

            _context.Products.Remove(dbProduct);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }
        
    }
}
