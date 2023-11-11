using MyStore.Domain;

namespace MyStore.Data
{
    public interface IEmployeeRepository
    {
        Employee Add(Employee employee);
        int Delete(Employee employee);
        IEnumerable<Employee> GetAll();
        Employee? GetEmployeeByID(int id);
        Employee Update(Employee employee);
    }
}