using MongoDB.Driver;
using OnlineFoodBooking.DataAccess.Abstraction;
using OnlineFoodBooking.DataAccess.Mongo;
using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.DataAcess.Mongo
{
    public class MongoDataRepository : IMongoDataRepository
    {
        MongoContextClass mongoContextClass = new MongoContextClass();
        
        IDataAccessRespository dataAccessRespository;
        List<MongoModel> mongomodel = new List<MongoModel>();
        List<FoodMenuApplicationModel> foodMenuApplicationModel = new List<FoodMenuApplicationModel>();
        public MongoDataRepository(IDataAccessRespository _dataAccessRespository)
        {
            dataAccessRespository = _dataAccessRespository;
        }

        public void PostToMongo(FoodMenuApplicationModel foodMenuApplicationModel)
        {

            MongoModel mongo = new MongoModel
            {
                FoodId = foodMenuApplicationModel.FoodId,
                FoodItem = foodMenuApplicationModel.FoodItem,
                Price = foodMenuApplicationModel.Price
            };

            mongoContextClass.GetMongoData.InsertOne(mongo);
        }

        public List<FoodMenuApplicationModel> GetDataFromMongo()
        {
           mongomodel = mongoContextClass.GetMongoData.AsQueryable().ToList();
            foreach (var item in mongomodel)
            {   
                foodMenuApplicationModel.Add(new FoodMenuApplicationModel
                {
                    FoodId = item.FoodId,
                    FoodItem = item.FoodItem,
                    Price = item.Price
                });
            }
            return foodMenuApplicationModel.ToList();
          
        }

        public List<CartDTO> GetOrders()
        {
            List<OrderMongo> orders = mongoContextClass.Orders.AsQueryable().ToList();
            List<CartDTO> cart = new List<CartDTO>();
            foreach (var item in orders)
            {
                List<FoodDTO> foods = new List<FoodDTO>();
                foreach (var food in item.Foods)
                {
                    foods.Add(new FoodDTO
                    {
                        FoodId = food.FoodId,
                        FoodItem = food.FoodItem,
                        Price = food.Price,
                        Quantity = food.Quantity
                    });
                }
                cart.Add(new CartDTO
                {
                    OrderId = item.OrderId,
                    TotalPrice = item.TotalPrice,
                    CustomerName = item.CustomerName,
                    Foods = foods,
                    Date = item.Date
                });

            }
            return cart;
        }

        public void PostCartDetailsToMongo(CartDTO cart)
        {
            List<FoodMongo> foods = new List<FoodMongo>();
            foreach (var item in cart.Foods)
            {
                foods.Add(new FoodMongo
                {
                    FoodId = item.FoodId,
                    Price = item.Price,
                    FoodItem = item.FoodItem,
                    Quantity = item.Quantity,
                });
            }
            OrderMongo CartData = new OrderMongo
            {
                OrderId = cart.OrderId,
                TotalPrice = cart.TotalPrice,
                CustomerName = cart.CustomerName,
                Foods = foods,
                Date = System.DateTime.Now.ToString()
            };
            mongoContextClass.Orders.InsertOne(CartData);                     
        }
    }
}
