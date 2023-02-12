using HPlusSport.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductsController(ShopContext context)
        {
            _context = context;

            // Seed the database.
            _context.Database.EnsureCreated();
        }

        //[HttpGet]
        //public IEnumerable<Product> GetAllProducts()
        //{
        //    return _context.Products.ToArray();
        //}

        //[HttpGet]
        //public ActionResult GetAllProducts()
        //{
        //    return Ok(_context.Products.ToArray());
        //}

        [HttpGet]
        public async Task<ActionResult> GetAllProductsAsync()
        {
            return Ok(await _context.Products.ToArrayAsync());
        }

        //[HttpGet("{id}")]
        //public ActionResult GetProduct(int id) 
        //{
        //    var product = _context.Products.Find(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(product);
        //}


        //[HttpGet("{id}")]
        [HttpGet]
        [Route("/api/Product/{id}")]
        public async Task<ActionResult> GetProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        { 
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }
    }
}
