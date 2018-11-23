﻿

using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.DataAccess.Abstraction
{
   public interface IDataAccessRespository
    {
        List<FoodMenuDomainModels> GetFoodMenu();
        void PostNewFoodItem(FoodMenuDomainModels foodMenu);
        List<FoodMenuApplicationModel> GetUnTransferedData();
    }
}
