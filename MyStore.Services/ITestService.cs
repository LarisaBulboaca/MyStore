using MyStore.Domain;

namespace MyStore.Services
{
    public interface ITestService
    {
        Test? GetTest(int id);
        IEnumerable<Test> GetTests();
        Test InsertNew(Test test);
        int Remove(Test test);
        Test Update(Test test);
    }
}