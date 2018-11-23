using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.Application.Abstraction
{
    public interface IOrderApplicationMethods
    {
#region ORDERAPPLICATION
        CartDTO AddOrder(CartDTO cart);
        void PostCartDetailsToMongo(CartDTO cart);
        List<CartDTO> GetOrders();
#endregion
    }
}
