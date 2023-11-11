using MyStore.Domain;

namespace MyStore.Data
{
    public interface ICustomerRepository
    {
        Customer Add(Customer shipper);
        int Delete(Customer shipper);
        IEnumerable<Customer> GetAll();
        Customer? GetCustomerByID(int id);
        Customer Update(Customer shipper);
    }
}