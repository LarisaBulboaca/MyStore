using MyStore.Domain;

namespace MyStore.Data
{
    public interface IOrderDetailRepository
    {
        OrderDetail Add(OrderDetail orderDetail);
        int Delete(OrderDetail orderDetail);
        IEnumerable<OrderDetail> GetAll();
        OrderDetail? GetOrderDetailByID(int orderId, int productId);
        OrderDetail Update(OrderDetail orderDetail);
    }
}