using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Order? GetOrder(int id)
        {
            var existingOrder = orderRepository.GetOrderByID(id);
            return existingOrder;
        }

        public IEnumerable<Order> GetOrders()
        {
            return orderRepository.GetAll();
        }

        public Order InsertNew(Order order)
        {
            return orderRepository.Add(order);
        }

        public int Remove(Order order)
        {
            return orderRepository.Delete(order);
        }

        public Order Update(Order order)
        {
            return orderRepository.Update(order);
        }
    }
}
