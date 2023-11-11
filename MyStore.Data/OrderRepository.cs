using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext storeContext;

        public OrderRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Order? GetOrderByID(int id)
        {
            return storeContext.Orders.Find(id);
        }

        public Order Add(Order order)
        {
            var addedEntity = storeContext.Orders.Add(order).Entity;
            storeContext.SaveChanges();
            return addedEntity;
        }

        public int Delete(Order order)
        {
            storeContext.Orders.Remove(order);
            return storeContext.SaveChanges();
        }

        public Order Update(Order order)
        {
            var updatedEntity = storeContext.Orders.Update(order).Entity;
            storeContext.SaveChanges();
            return updatedEntity;
        }

        public IEnumerable<Order> GetAll()
        {
            return storeContext.Orders.ToList();
        }
    }
}
