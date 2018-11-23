using Hangfire;
using OnlineFoodBooking.Application.Abstraction;
using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineFoodBooking.Controllers.OrdersApi
{
    public class OrdersApiController : ApiController
    {
        private IOrderApplicationMethods orderApplicationMethods;
        public OrdersApiController(IOrderApplicationMethods orderApplicationMethods)
        {
            this.orderApplicationMethods = orderApplicationMethods;
        }
        [HttpPost]
        public IHttpActionResult Post(CartDTO cart)
        {
            var cartWithOrderId = orderApplicationMethods.AddOrder(cart);
            // Hangfire job for mongo
            BackgroundJob.Enqueue(() => orderApplicationMethods.PostCartDetailsToMongo(cartWithOrderId));
            return Created("/api/OrdersApi", cartWithOrderId);
        }
        public IHttpActionResult GetOrders()
        {
           return Ok( orderApplicationMethods.GetOrders());

        }
    }
}
