using MyStore.Domain;

namespace MyStore.Data
{
    public interface ITestRepository
    {
        Test Add(Test test);
        int Delete(Test test);
        IEnumerable<Test> GetAll();
        Test? GetTestByID(int id);
        Test Update(Test test);
    }
}