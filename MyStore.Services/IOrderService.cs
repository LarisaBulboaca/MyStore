using MyStore.Domain;

namespace MyStore.Services
{
    public interface IOrderService
    {
        Order? GetOrder(int id);
        IEnumerable<Order> GetOrders();
        Order InsertNew(Order order);
        int Remove(Order order);
        Order Update(Order order);
    }
}