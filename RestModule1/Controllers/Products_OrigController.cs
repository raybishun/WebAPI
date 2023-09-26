using RestModule1.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestModule1.Controllers
{
    public class Products_OrigController : ApiController
    {
        static List<Product> products = new List<Product>()
        { 
            new Product(){ Id = 0, ProductName = "Apple", Price = 20},
            new Product(){ Id = 1, ProductName = "Banana", Price = 40},
            new Product(){ Id = 2, ProductName = "Orange", Price = 60}
        };

        // GET: api/Product
        // public IEnumerable<string> Get()
        // public IEnumerable<Product> Get()
        // public HttpResponseMessage Get()

        // [HttpGet] // Custom Method
        public IHttpActionResult Get()
        {
            // return new string[] { "value1", "value2" };
            // return products;

            // return BadRequest(); // HTTP 404
            // return NotFound();

            // return new HttpResponseMessage(HttpStatusCode.Created); // HTTP 201
            // return new HttpResponseMessage(HttpStatusCode.OK);

            return Ok(products); // HTTP 200
        }

        // GET: api/Product/5
        // public string Get(int id)
        public Product Get(int id)
        {
            // return "value";
            return products[id];
        }

        // POST: api/Product
        // public void Post([FromBody]string value)
        // public void Post([FromBody] Product product)
        
        [HttpPost] // Custom Method
        public HttpResponseMessage Post([FromBody]Product product)
        {
            products.Add(product);
            return new HttpResponseMessage(HttpStatusCode.Created);

            /*
             Test with Postman: 
            --> URL: http://localhost:57551/api/products
            --> POST 
            --> Body --> Raw --> JSON (application/json)
                {
                    "Id": 3,
                    "ProductName": "Mango",
                    "Price": 80
                }
            --> Send
            --> GET: http://localhost:57551/api/products
            */
        }

        // PUT: api/Product/5
        // public void Put(int id, [FromBody]string value)

        [HttpPut] // Custom Method
        // public void Put(int id, [FromBody] Product product)
        // public void Put(int id, [FromUri] Product product)
        public void Put([FromBody]int id, [FromUri] Product product)
        {
            products[id] = product;

            // When passed using [FromUri]: http://localhost:57551/api/products?id=1&ProductName=NokiaPhone&Price=300

            // When passed using the [FromBody]int id, [FromUri]: http://localhost:57551/api/products?ProductName=MotorollaPhone&Price=200

            /*
            Test with Postman: 
            --> URL: http://localhost:57551/api/products/3
            --> PUT
            --> Body --> Raw --> JSON (application/json)
                {
                    "Id": 3,
                    "ProductName": "Tomato",
                    "Price": 90
                }
            --> Send
            --> GET: http://localhost:57551/api/products
            */
        }

        // DELETE: api/Product/5
        // public void Delete(int id)

        [HttpDelete] // Custom Method
        public void Delete(int id)
        {
            products.RemoveAt(id);

            /*
            Test with Postman: 
            --> URL: http://localhost:57551/api/products/3
            --> DELETE
            --> Send
            --> GET: http://localhost:57551/api/products
            */
        }
    }
}
