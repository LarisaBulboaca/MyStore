using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly StoreContext storeContext;

        public OrderDetailRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public OrderDetail? GetOrderDetailByID(int id)
        {
            return storeContext.OrderDetails.Find(id);
        }

        public OrderDetail Add(OrderDetail orderDetail)
        {
            var addedEntity = storeContext.OrderDetails.Add(orderDetail).Entity;
            storeContext.SaveChanges();
            return addedEntity;
        }

        public int Delete(OrderDetail orderDetail)
        {
            storeContext.OrderDetails.Remove(orderDetail);
            return storeContext.SaveChanges();
        }

        public OrderDetail Update(OrderDetail orderDetail)
        {
            var updatedEntity = storeContext.OrderDetails.Update(orderDetail).Entity;
            storeContext.SaveChanges();
            return updatedEntity;
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return storeContext.OrderDetails.ToList();
        }
    }
}
