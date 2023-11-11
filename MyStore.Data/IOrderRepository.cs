using MyStore.Domain;

namespace MyStore.Data
{
    public interface IOrderRepository
    {
        Order Add(Order order);
        int Delete(Order order);
        IEnumerable<Order> GetAll();
        Order? GetOrderByID(int id);
        Order Update(Order order);
    }
}