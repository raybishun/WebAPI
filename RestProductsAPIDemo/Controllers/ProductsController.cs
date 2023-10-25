using System.Collections;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RestProductsAPIDemo.Models;

namespace RestProductsAPIDemo.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductsDBEntities db = new ProductsDBEntities();

        /*First page: http://localhost:51238/api/Products?pageNumber=1&pageSize=3
         * Second page: http://localhost:51238/api/Products?pageNumber=2&pageSize=3
         * If NULL: http://localhost:51238/api/Products?pageNumber=&pageSize
         */

        // GET: api/Products
        public IQueryable<ProductsTable> GetProductsTables(int? pageNumber, int? pageSize)
        {
            var products = (from p in db.ProductsTables.
                            OrderBy(a => a.ID)
                            select p).AsQueryable();

            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;
            
            var items = products.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).ToList();
           
           return items.AsQueryable();
           
        }

        //// GET: api/Products
        //public IQueryable<ProductsTable> GetProductsTables(string sortPrice)
        //{
        //    /*
        //     * http://localhost:51238/api/Products?sortPrice=desc
        //     */

        //    IQueryable<ProductsTable> products;
        //    switch (sortPrice)
        //    {
        //        case "desc":
        //            products = db.ProductsTables.OrderByDescending(p => p.Price);
        //            break;
        //        case "asc":
        //            products = db.ProductsTables.OrderBy(p => p.Price);
        //            break;
        //        default:
        //            products = db.ProductsTables;
        //            break;
        //    }
        //    // return db.ProductsTables;
        //    return products;
        //}

        // GET: api/Products/5
        [ResponseType(typeof(ProductsTable))]
        public async Task<IHttpActionResult> GetProductsTable(int id)
        {
            ProductsTable productsTable = await db.ProductsTables.FindAsync(id);
            if (productsTable == null)
            {
                return NotFound();
            }

            return Ok(productsTable);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductsTable(int id, ProductsTable productsTable)
        {
            /*http://localhost:51238/api/Products/1
             *     {
                    "Id": 1,
                    "ProductName": "Donut",
                    "Price": 20
                }

            GET: http://localhost:51238/api/Products/1
             */

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productsTable.ID)
            {
                return BadRequest();
            }

            db.Entry(productsTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Return 204 - Request successfully processed and response intentionally blank.
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(ProductsTable))]
        public async Task<IHttpActionResult> PostProductsTable(ProductsTable productsTable)
        {
            /* 
             * {
                "ID": 6,
                "ProductName": "Burger",
                "Price": 20
            }
             */

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductsTables.Add(productsTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productsTable.ID }, productsTable);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(ProductsTable))]
        public async Task<IHttpActionResult> DeleteProductsTable(int id)
        {
            /*DELETE: http://localhost:51238/api/Products/1
             *     {
                    "Id": 1,
                    "ProductName": "Donut",
                    "Price": 20
                }
            GET: http://localhost:51238/api/Products/1 (returns, 404 Not Found)
             */

            ProductsTable productsTable = await db.ProductsTables.FindAsync(id);
            if (productsTable == null)
            {
                return NotFound();
            }

            db.ProductsTables.Remove(productsTable);
            await db.SaveChangesAsync();

            return Ok(productsTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductsTableExists(int id)
        {
            return db.ProductsTables.Count(e => e.ID == id) > 0;
        }
    }
}