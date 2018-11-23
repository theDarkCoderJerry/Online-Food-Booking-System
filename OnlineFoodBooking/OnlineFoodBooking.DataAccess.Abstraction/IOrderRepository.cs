using OnlineFoodBookingModels;
using System.Collections.Generic;

namespace OnlineFoodBooking.DataAccess.Abstraction
{
    public interface IOrderRepository
    {
        OrderDTO PostOrder(OrderDTO order);
        List<OrderDetailDTO> PostOrderDetails(List<OrderDetailDTO> orderDetails);
    }
}
