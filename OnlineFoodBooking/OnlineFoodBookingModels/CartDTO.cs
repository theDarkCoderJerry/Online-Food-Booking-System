using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodBookingModels
{
    public class CartDTO
    {
        public int OrderId { get; set; }
        public int TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public string Date { get; set; }
        public List<FoodDTO> Foods;
    }

    public class FoodDTO
    {
        public int FoodId { get; set; }
        public string FoodItem { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}