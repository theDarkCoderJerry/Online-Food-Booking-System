using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineFoodBooking.Controllers
{
    public class ElasticSearchApiController : ApiController
    {
        public IHttpActionResult Search(string id)
        {

            return Ok();
        }
    }
}
