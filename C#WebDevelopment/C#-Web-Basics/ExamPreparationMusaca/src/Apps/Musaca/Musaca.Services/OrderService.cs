using Microsoft.EntityFrameworkCore;
using Musaca.Data;
using Musaca.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Musaca.Services
{
    public class OrderService : IOrderService
    {
        private readonly MusacaDbContext context;

        public OrderService(MusacaDbContext context)
        {
            this.context = context;
        }

        public bool AddProductToCurrentOrder(string productId, string userId)
        {
            var product = this.context.Products.SingleOrDefault(p => p.Id == productId);
            var currentActiveOrder = this.GetCurrentActiveOrderByCashierId(userId);

            currentActiveOrder.Products.Add(product);

            this.context.Update(currentActiveOrder);
            this.context.SaveChanges();

            return true;
        }

        public Order CompleteOrderById(string orderId, string userId)
        {
            var orders = this.context.Orders.SingleOrDefault(order => order.Id == orderId);

            orders.IssuedOn = DateTime.UtcNow;
            orders.Status = OrderStatus.Completed;

            this.context.Update(orders);
            this.context.SaveChanges();

            this.CreateOrder(new Order { CashierId = userId });

            return orders;
        }

        public Order CreateOrder(Order order)
        {
            this.context.Add(order);
            this.context.SaveChanges();

            return order;
        }

        public List<Order> GetAllCompletedOrderByCashierId(string userId)
        {
            var orders = this.context.Orders
                .Include(order => order.Products)
                .Include(order => order.Cashier)
                .Where(order => order.CashierId == userId)
                .Where(order => order.Status == OrderStatus.Completed)
                .ToList();

            return orders;
        }

        public Order GetCurrentActiveOrderByCashierId(string userId)
        {
            var orders = this.context.Orders
                .Include(order => order.Products)
                .Include(order => order.Cashier)
                .SingleOrDefault(order => order.CashierId == userId && order.Status == OrderStatus.Active);

            return orders;
        }
    }
}
