using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly StoreContext storeContext;

        public EmployeeRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Employee? GetEmployeeByID(int id)
        {
            return storeContext.Employees.Find(id);
        }

        public Employee Add(Employee employee)
        {
            var addedEntity = storeContext.Employees.Add(employee).Entity;
            storeContext.SaveChanges();
            return addedEntity;
        }

        public int Delete(Employee employee)
        {
            storeContext.Employees.Remove(employee);
            return storeContext.SaveChanges();
        }

        public Employee Update(Employee employee)
        {
            var updatedEntity = storeContext.Employees.Update(employee).Entity;
            storeContext.SaveChanges();
            return updatedEntity;
        }

        public IEnumerable<Employee> GetAll()
        {
            return storeContext.Employees.ToList();
        }
    }
}
