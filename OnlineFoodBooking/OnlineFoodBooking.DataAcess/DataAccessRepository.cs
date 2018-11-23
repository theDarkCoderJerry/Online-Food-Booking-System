using OnlineFoodBooking.DataAccess.Abstraction;
using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.DataAcess
{
   
    public class DataAccessRepository : IDataAccessRespository
    {
        OnlineFoodBookingEntities db = new OnlineFoodBookingEntities();
        FoodMenu _foodMenu = new FoodMenu();
        List<FoodMenu> foodMenu = new List<FoodMenu>();
        List<FoodMenuDomainModels> foodMenuRepository = new List<FoodMenuDomainModels>();

        public List<FoodMenuDomainModels> GetFoodMenu()
        {
            foodMenu = db.FoodMenus.ToList();


            foreach(var item in foodMenu)
            {
                foodMenuRepository.Add(new FoodMenuDomainModels
                {
                    FoodId = item.FoodId,
                    FoodItem = item.FoodItem,
                    Price = (int)item.Price,
                    Sync = (bool)item.Sync
                });
            }

            return foodMenuRepository.ToList();
        }

        public void PostNewFoodItem(FoodMenuDomainModels foodMenuRepository)
        {
            _foodMenu.FoodItem = foodMenuRepository.FoodItem;
            _foodMenu.Price = foodMenuRepository.Price;
            _foodMenu.Sync = false;
            db.FoodMenus.Add(_foodMenu);
            db.SaveChanges();
        }


        public List<FoodMenuApplicationModel> GetUnTransferedData()
        {
          IQueryable< FoodMenu> UnTransferedData = db.FoodMenus.Where(w => w.Sync == false);
            List<FoodMenuApplicationModel> foodMenuApplicationModelList = new List<FoodMenuApplicationModel>();
            foreach (var item in UnTransferedData)
            {
               item.Sync = true;
                FoodMenuApplicationModel foodMenuApplicationModel = new FoodMenuApplicationModel
                {
                    FoodId = item.FoodId,
                    FoodItem = item.FoodItem,
                    Price = (int)item.Price
                };
                
                foodMenuApplicationModelList.Add(foodMenuApplicationModel);
            }
            db.SaveChanges();
            return foodMenuApplicationModelList;


        }



    }
}
