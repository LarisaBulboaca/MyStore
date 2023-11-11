using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Employee? GetEmployee(int id)
        {
            var existingEmployee = employeeRepository.GetEmployeeByID(id);
            return existingEmployee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employeeRepository.GetAll();
        }

        public Employee InsertNew(Employee employee)
        {
            return employeeRepository.Add(employee);
        }

        public int Remove(Employee employee)
        {
            return employeeRepository.Delete(employee);
        }

        public Employee Update(Employee employee)
        {
            return employeeRepository.Update(employee);
        }
    }
}
