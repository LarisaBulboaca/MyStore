using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            this.orderDetailRepository = orderDetailRepository;
        }

        public OrderDetail? GetOrderDetail(int orderId, int productId)
        {
            var existingOrderDetail = orderDetailRepository.GetOrderDetailByID(orderId, productId);
            return existingOrderDetail;
        }

        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            return orderDetailRepository.GetAll();
        }

        public OrderDetail InsertNew(OrderDetail orderDetail)
        {
            return orderDetailRepository.Add(orderDetail);
        }

        public int Remove(OrderDetail orderDetail)
        {
            return orderDetailRepository.Delete(orderDetail);
        }

        public OrderDetail Update(OrderDetail orderDetail)
        {
            return orderDetailRepository.Update(orderDetail);
        }
    }
}
