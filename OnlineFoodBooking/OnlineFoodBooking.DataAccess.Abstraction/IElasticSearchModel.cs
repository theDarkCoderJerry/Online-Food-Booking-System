using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.DataAccess.Abstraction
{
   public interface IElasticSearchModel
    {
        void Post(FoodMenuApplicationModel foodMenuApplicationModel);
        List<FoodMenuApplicationModel> GetSearchResult(string stringToSearch);
    }
}
