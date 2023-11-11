using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer? GetCustomer(int id)
        {
            var existingCustomer = customerRepository.GetCustomerByID(id);
            return existingCustomer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return customerRepository.GetAll();
        }

        public Customer InsertNew(Customer customer)
        {
            return customerRepository.Add(customer);
        }

        public int Remove(Customer customer)
        {
            return customerRepository.Delete(customer);
        }

        public Customer Update(Customer customer)
        {
            return customerRepository.Update(customer);
        }
    }
}
