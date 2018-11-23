
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBookingModels
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int TotalPrice { get; set; }
        public string CustomerName { get; set; }
    }
}
