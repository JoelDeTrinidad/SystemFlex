using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SystemFlexWebApi.Tools
{
    public class HandleHttpError : IHttpActionResult
    {
        HttpStatusCode Code;
        String Message;

        public HandleHttpError(HttpStatusCode Code, String Message)
        {
            this.Code = Code;
            this.Message = Message;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(Code);
            response.Content = new StringContent(Message);
            return Task.FromResult(response);
        }
    }
}
