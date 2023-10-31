using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiOAuth2.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        /*  GET: https://localhost:44354/api/values
         *  {
                "Message": "Authorization has been denied for this request."
            }

        ------------------------------------------------
        NOTE: See AccountController for more info
        
        GET: https://localhost:44354/Token
        
        BODY --> x-www-form-urlencoded
        Key, Value
            username,user1@gmail.com
            password,P@ssw0rd
            grant_type,password

        {
            "access_token": "...",
            "token_type": "bearer",
            "expires_in": 1209599,
            "userName": "user1@gmail.com",
            ".issued": "Tue, 31 Oct 2023 00:42:39 GMT",
            ".expires": "Tue, 14 Nov 2023 00:42:39 GMT"
        
         GET: https://localhost:44354/api/values
            Headers:
            Key = Authorization
            Value = bearer {space and the above access_token value}
         */


        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
