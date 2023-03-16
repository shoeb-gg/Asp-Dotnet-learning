using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public async Task<ActionResult<List<Product>>> GetCars()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<List<Product>>> GetCarById(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return BadRequest("Product Not found");

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> CreateCar([FromBody] Product productCreate)
        {
            _context.Products.Add(productCreate);
            await _context.SaveChangesAsync();

            return Ok("Product Created !");
        }

        [HttpPost("multiple")]
        public async Task<ActionResult<List<Product>>> CreateCarMultiple([FromBody] Product[] productCreateArray)
        {
            IList<Product> newProducts = productCreateArray;
            //foreach (var product in productCreateArray)
            //{
                _context.Products.AddRange(newProducts);
            //}

            await _context.SaveChangesAsync();
            return Ok("All Products Created !");
        }


        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateCare([FromBody] Product productUpdate)
        {
            var product = await _context.Products.FindAsync(productUpdate.Id);
            if (product == null)
                return BadRequest("Car Not Found !");

            product.Name = productUpdate.Name;
            product.Brand = productUpdate.Brand;
            product.Description = productUpdate.Description;
            product.Price = productUpdate.Price;
            product.ImageUrl = productUpdate.ImageUrl;

            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteCare([FromBody] int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                return BadRequest("Product Not Found !");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok("Product Deleted !");
        }
    }
}
