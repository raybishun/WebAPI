using HPlusSport.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        //[HttpGet]
        //public async Task<ActionResult> GetAllProductsAsync()
        //{
        //    return Ok(await _context.Products.ToArrayAsync());
        //}


        // Usage: 5 on a page, starting at page 1: https://localhost:7218/api/products?size=5&page=1
        //[HttpGet]
        //public async Task<ActionResult> GetAllProductsAsync([FromQuery]QueryParameters queryParameters)
        //{
        //    IQueryable<Product> products = _context.Products;

        //    products = products
        //        .Skip(queryParameters.Size * (queryParameters.Page - 1))
        //        .Take(queryParameters.Size);

        //    return Ok(await products.ToArrayAsync());
        //}


        /*
            Usage 1: https://localhost:7218/api/products?maxPrice=50
            Usage 2: https://localhost:7218/api/products?maxPrice=50&minPrice=20
         */
        //[HttpGet]
        //public async Task<ActionResult> GetAllProductsAsync([FromQuery] ProductQueryParameters queryParameters)
        //{
        //    IQueryable<Product> products = _context.Products;

        //    if (queryParameters.MinPrice != null)
        //    {
        //        products = products.Where(
        //            p => p.Price >= queryParameters.MinPrice.Value);
        //    }

        //    if (queryParameters.MaxPrice != null)
        //    {
        //        products = products.Where(
        //            p => p.Price <= queryParameters.MaxPrice.Value);
        //    }

        //    products = products
        //        .Skip(queryParameters.Size * (queryParameters.Page - 1))
        //        .Take(queryParameters.Size);

        //    return Ok(await products.ToArrayAsync());
        //}



        //[HttpGet]
        //public async Task<ActionResult> GetAllProductsAsync([FromQuery] ProductQueryParameters queryParameters)
        //{
        //    IQueryable<Product> products = _context.Products;

        //    // Filtering
        //    if (queryParameters.MinPrice != null)
        //    {
        //        products = products.Where(
        //            p => p.Price >= queryParameters.MinPrice.Value);
        //    }

        //    if (queryParameters.MaxPrice != null)
        //    {
        //        products = products.Where(
        //            p => p.Price <= queryParameters.MaxPrice.Value);
        //    }


        //    // Search
        //    // Usage 1: https://localhost:7218/api/products?maxPrice=50&minPrice=20&sku=AWMPS
        //    // Usage 2: https://localhost:7218/api/products?name=jeans
        //    if (!string.IsNullOrEmpty(queryParameters.Sku))
        //    {
        //        products = products.Where(
        //            p => p.Sku == queryParameters.Sku);
        //    }

        //    if (!string.IsNullOrEmpty(queryParameters.Name))
        //    {
        //        products = products.Where(
        //            p => p.Name.ToLower().Contains(queryParameters.Name.ToLower()));
        //    }

        //    // Pagination
        //    products = products
        //        .Skip(queryParameters.Size * (queryParameters.Page - 1))
        //        .Take(queryParameters.Size);

        //    return Ok(await products.ToArrayAsync());
        //}



        [HttpGet]
        public async Task<ActionResult> GetAllProductsAsync([FromQuery] ProductQueryParameters queryParameters)
        {
            IQueryable<Product> products = _context.Products;

            // Filtering
            if (queryParameters.MinPrice != null)
            {
                products = products.Where(
                    p => p.Price >= queryParameters.MinPrice.Value);
            }

            if (queryParameters.MaxPrice != null)
            {
                products = products.Where(
                    p => p.Price <= queryParameters.MaxPrice.Value);
            }


            // Search
            // Usage 1: https://localhost:7218/api/products?maxPrice=50&minPrice=20&sku=AWMPS
            // Usage 2: https://localhost:7218/api/products?name=jeans
            if (!string.IsNullOrEmpty(queryParameters.Sku))
            {
                products = products.Where(
                    p => p.Sku == queryParameters.Sku);
            }

            if (!string.IsNullOrEmpty(queryParameters.Name))
            {
                products = products.Where(
                    p => p.Name.ToLower().Contains(queryParameters.Name.ToLower()));
            }

            // Sorting
            // Usage 1: https://localhost:7218/api/products?sortBy=Price
            // Usage 2: https://localhost:7218/api/products?sortBy=Price&sortOrder=desc
            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (typeof(Product).GetProperty(queryParameters.SortBy) != null)
                {
                    products = products.OrderByCustom(
                        queryParameters.SortBy,
                        queryParameters.SortOrder);
                }
            }

            // Pagination
            products = products
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(await products.ToArrayAsync());
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
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}
                        
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(p => p.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        { 
            var product = await _context.Products.FindAsync(id);

            if (product == null) 
            { 
                return NotFound();
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return product;
        }

        [HttpPost]
        [Route("Delete")] // Usage: https://localhost:7218/api/products/delete?ids=1&ids=2&ids=3&ids=33
        public async Task<ActionResult> DeleteProducts([FromQuery]int[] ids)
        {
            var products = new List<Product>();

            foreach (var id in ids)
            {
                var product = await _context.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound();
                }

                products.Add(product);
            }

            _context.Products.RemoveRange(products);

            await _context.SaveChangesAsync();

            return Ok(products);
        }
    }
}
