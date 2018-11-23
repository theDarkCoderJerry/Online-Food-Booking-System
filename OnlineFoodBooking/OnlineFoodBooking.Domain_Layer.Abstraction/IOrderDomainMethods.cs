using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.Domain_Layer.Abstraction
{
   public interface IOrderDomainMethods
    {
        CartDTO AddOrder(CartDTO cart);
        void PostCartDetailsToMongo(CartDTO cart);
        List<CartDTO> GetOrders();
    }
}
