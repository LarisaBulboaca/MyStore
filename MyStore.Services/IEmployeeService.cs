using MyStore.Domain;

namespace MyStore.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        Employee? GetEmployee(int id);
        Employee InsertNew(Employee employee);
        int Remove(Employee employee);
        Employee Update(Employee employee);
    }
}