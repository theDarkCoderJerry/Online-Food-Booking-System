using Hangfire;
using OnlineFoodBooking.Application.Abstraction;
using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineFoodBooking.Controllers
{
    public class OnlineFoodController : ApiController
    {
        private IFoodMenuApplicationMethods foodMenuApplicationMethods;
        private FoodMenuApplicationModel foodMenuApplicationModel;
        public OnlineFoodController(IFoodMenuApplicationMethods _foodMenuApplicationMethods)
        {
            foodMenuApplicationMethods = _foodMenuApplicationMethods;

        }
        public IHttpActionResult GetFoodMenuapi()
        {
            return Ok(foodMenuApplicationMethods.GetFoodMenu());
        }
       
        [HttpPost]
        public IHttpActionResult PostNewFoodItemapi(FoodMenuApplicationModel foodMenuPresentationModel)
        {
            //foodMenuApplicationModel.FoodItem = foodMenuPresentationModel.FoodItem;
            //foodMenuApplicationModel.Price = foodMenuPresentationModel.Price;
            foodMenuApplicationMethods.PostNewFoodItem(foodMenuPresentationModel);
            BackgroundJob.Enqueue(() => foodMenuApplicationMethods.SyncDatabases());
            return Ok();
        }

        public IHttpActionResult GetDataFromMongoapi()
        {
            return Ok(foodMenuApplicationMethods.GetDataFromMongo());
        }

        [HttpGet]
      public IHttpActionResult SearchResults(string id)
        {
            
            return Ok(foodMenuApplicationMethods.GetSearchResult(id));
        }
    }
}
