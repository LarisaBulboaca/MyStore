using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository testRepository;

        public TestService(ITestRepository testRepository)
        {
            this.testRepository = testRepository;
        }

        public Test? GetTest(int id)
        {
            var existingTest = testRepository.GetTestByID(id);
            return existingTest;
        }

        public IEnumerable<Test> GetTests()
        {
            return testRepository.GetAll();
        }

        public Test InsertNew(Test test)
        {
            return testRepository.Add(test);
        }

        public int Remove(Test test)
        {
            return testRepository.Delete(test);
        }

        public Test Update(Test test)
        {
            return testRepository.Update(test);
        }
    }
}
