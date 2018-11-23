using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.DataAccess.Mongo
{
    public class OrderMongo
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int OrderId { get; set; }
        public int TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public string Date { get; set; }
        public List<FoodMongo> Foods;
    }

    public class FoodMongo
    {
        public int FoodId { get; set; }
        public string FoodItem { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
