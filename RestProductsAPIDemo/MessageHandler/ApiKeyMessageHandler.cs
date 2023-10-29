using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace RestProductsAPIDemo.MessageHandler
{
    public class ApiKeyMessageHandler : DelegatingHandler
    {
        private const string APIKey = "8954dd18ef7e45f19e0d3ca49b017004";

        /*Attempt #1 of 2 - GET: http://localhost:51238/api/Products/5
         * Returned in BODY: "Invalid API Key"
         * 
         * 
         *Attempt #2 of 2 - GET: http://localhost:51238/api/Products/5
         * Headers
         *    Key = APiKey  Value = 8954dd18ef7e45f19e0d3ca49b017004
         */


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool validKey = false;
            
            IEnumerable<string> requestHeaders;
            
            var apiExists = request.Headers.TryGetValues("ApiKey", out requestHeaders);
            
            if (apiExists)
            {
                if (requestHeaders.FirstOrDefault().Equals(APIKey))
                {
                    validKey = true;
                }
            }

            if (!validKey) 
            {
                return request.CreateResponse(HttpStatusCode.Forbidden, "Invalid API Key");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}