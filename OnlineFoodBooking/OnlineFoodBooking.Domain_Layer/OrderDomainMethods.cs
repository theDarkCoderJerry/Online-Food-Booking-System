using OnlineFoodBooking.Domain_Layer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineFoodBookingModels;
using OnlineFoodBooking.DataAccess.Abstraction;

namespace OnlineFoodBooking.Domain_Layer
{
    public class OrderDomainMethods : IOrderDomainMethods
    {
        private IOrderRepository orderRepository;
        IMongoDataRepository mongoDataRepository;
        public OrderDomainMethods(IOrderRepository orderRepository , IMongoDataRepository mongoDataRepository )
        {
            this.mongoDataRepository = mongoDataRepository;
            this.orderRepository = orderRepository;
        }
        public CartDTO AddOrder(CartDTO cart)
        {
            OrderDTO orderToPost = new OrderDTO
            {
                TotalPrice = cart.TotalPrice,
                CustomerName = cart.CustomerName
            };
            var orderAfterPost = orderRepository.PostOrder(orderToPost);
            List<OrderDetailDTO> orderDetailsToPost = new List<OrderDetailDTO>();
            foreach (var food in cart.Foods)
            {
                orderDetailsToPost.Add(new OrderDetailDTO
                {
                    OrderId = orderAfterPost.OrderId,
                    FoodId = food.FoodId,
                    Quantity = food.Quantity
                });
            }
            orderRepository.PostOrderDetails(orderDetailsToPost);
            cart.OrderId = orderAfterPost.OrderId;
            return cart;
        }

        public void PostCartDetailsToMongo(CartDTO cart)
        {
            mongoDataRepository.PostCartDetailsToMongo(cart);
        }

        public List<CartDTO> GetOrders()
        {
            return mongoDataRepository.GetOrders();
        }
    }
}
