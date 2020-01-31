using Musaca.Models;
using System.Collections.Generic;

namespace Musaca.Services
{
    public interface IOrderService
    {
        Order CreateOrder(Order order);

        Order CompleteOrderById(string orderId, string userId);

        List<Order> GetAllCompletedOrderByCashierId(string userId);

        Order GetCurrentActiveOrderByCashierId(string userId);
    }
}
