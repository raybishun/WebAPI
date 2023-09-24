using RestModule1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestModule1.Controllers
{
    public class CustomersController : ApiController
    {
        static List<Customer> customers = new List<Customer>()
        {
            new Customer(){Id=1,Name="Tom Cruise",Email="tomcruise@gmail.com",Phone="3322"},
            new Customer(){Id=1,Name="Robert Downy Jr",Email="robert@gmail.com",Phone="326"},
            new Customer(){Id=1,Name="Chris Patt",Email="cpatt@hotmail.com",Phone="659"}
        };
        
        // GET: api/Customers
        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        // GET: api/Customers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customers
        public IHttpActionResult Post([FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                customers.Add(customer);
                return Ok();
            }
            return BadRequest(ModelState);

            /*
             * {
                    "Id": 4,
                    "Name": "Tony ",
                    "Email": "2233za",
                    "Phone": "ABC007"
                }

            Results:
            {
                "Message": "The request is invalid.",
                "ModelState": {
                    "customer.Email": [
                        "Invalid email address."
                    ],
                    "customer.Phone": [
                        "Invalid phone number."
                    ]
                }
            }

             */
        }

        // PUT: api/Customers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customers/5
        public void Delete(int id)
        {
        }
    }
}
