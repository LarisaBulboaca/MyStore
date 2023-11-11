using MyStore.Domain;

namespace MyStore.Services
{
    public interface IOrderDetailService
    {
        OrderDetail? GetOrderDetail(int orderId, int productId);
        IEnumerable<OrderDetail> GetOrderDetails();
        OrderDetail InsertNew(OrderDetail orderDetail);
        int Remove(OrderDetail orderDetail);
        OrderDetail Update(OrderDetail orderDetail);
    }
}