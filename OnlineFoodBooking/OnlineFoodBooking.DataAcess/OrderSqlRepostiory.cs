using OnlineFoodBooking.DataAccess.Abstraction;
using OnlineFoodBookingModels;
using System.Collections.Generic;

namespace OnlineFoodBooking.DataAcess
{
    public class OrderSqlRepostiory : IOrderRepository
    {
        private OnlineFoodBookingEntities db = new OnlineFoodBookingEntities();

        public OrderDTO PostOrder(OrderDTO order)
        {
            Order orderToPost = new Order
            {
                TotalPrice = order.TotalPrice,
                CustomerName = order.CustomerName
            };
            db.Orders.Add(orderToPost);
            db.SaveChanges();
            order.OrderId = orderToPost.OrderId;
            return order;
        }

        public List<OrderDetailDTO> PostOrderDetails(List<OrderDetailDTO> orderDetails)
        {
            List<OrderDetail> orderDetailsToPost = new List<OrderDetail>();
            foreach (var orderDetail in orderDetails)
            {
                orderDetailsToPost.Add(new OrderDetail {
                    OrderId = orderDetail.OrderId,
                    FoodId = orderDetail.FoodId,
                    Qty = orderDetail.Quantity
                });
            }
            db.OrderDetails.AddRange(orderDetailsToPost);
            db.SaveChanges();
            return orderDetails;
        }
    }
}
