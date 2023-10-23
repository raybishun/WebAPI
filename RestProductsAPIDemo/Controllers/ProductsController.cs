﻿using System.Data.Entity;
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

        // GET: api/Products
        public IQueryable<ProductsTable> GetProductsTables()
        {
            return db.ProductsTables;
        }

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
            /*PUT: http://localhost:51238/api/Products/1
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