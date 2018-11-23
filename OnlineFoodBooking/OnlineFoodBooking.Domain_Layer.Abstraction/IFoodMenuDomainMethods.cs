using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.Domain_Layer.Abstraction
{
    public interface IFoodMenuDomainMethods
    {
        List<FoodMenuDomainModels> GetFoodMenu();
        void PostNewFoodItem(FoodMenuDomainModels foodMenuDomainModels);
        void SyncDatabases();
        List<FoodMenuApplicationModel> GetDataFromMongo();
        List<FoodMenuApplicationModel> GetSearchResult(string stringToSearch);

    }
}
