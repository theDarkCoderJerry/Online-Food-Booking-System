using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.DataAccess.Abstraction
{
   public interface IMongoDataRepository
    {
        void PostToMongo(FoodMenuApplicationModel foodMenuApplicationModel);
        List<FoodMenuApplicationModel> GetDataFromMongo();
        void PostCartDetailsToMongo(CartDTO cart);
        List<CartDTO> GetOrders();
    }
}
