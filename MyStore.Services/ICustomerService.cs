using MyStore.Domain;

namespace MyStore.Services
{
    public interface ICustomerService
    {
        Customer? GetCustomer(int id);
        IEnumerable<Customer> GetCustomers();
        Customer InsertNew(Customer customer);
        int Remove(Customer customer);
        Customer Update(Customer customer);
    }
}