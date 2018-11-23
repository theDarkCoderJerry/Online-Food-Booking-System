using OnlineFoodBooking.Application.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineFoodBookingModels;
using OnlineFoodBooking.Domain_Layer.Abstraction;

namespace OnlineFoodBooking.Application_Layer
{
    public class OrderApplicationMethods : IOrderApplicationMethods
    {
        private IOrderDomainMethods orderDomainMethods;
        public OrderApplicationMethods(IOrderDomainMethods orderDomainMethods)
        {
            this.orderDomainMethods = orderDomainMethods;
        }
        public CartDTO AddOrder(CartDTO cart)
        {
            return orderDomainMethods.AddOrder(cart);
        }

        public void PostCartDetailsToMongo(CartDTO cart)
        {
            orderDomainMethods.PostCartDetailsToMongo(cart);
        }
        public List<CartDTO> GetOrders()
        {
           return orderDomainMethods.GetOrders();
        }
    }
}
