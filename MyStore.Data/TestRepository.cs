using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class TestRepository : ITestRepository
    {
        private readonly StoreContext storeContext;

        public TestRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Test? GetTestByID(int id)
        {
            return storeContext.Tests.Find(id);
        }

        public Test Add(Test test)
        {
            var addedEntity = storeContext.Tests.Add(test).Entity;
            storeContext.SaveChanges();
            return addedEntity;
        }

        public int Delete(Test test)
        {
            storeContext.Tests.Remove(test);
            return storeContext.SaveChanges();
        }

        public Test Update(Test test)
        {
            var updatedEntity = storeContext.Tests.Update(test).Entity;
            storeContext.SaveChanges();
            return updatedEntity;
        }

        public IEnumerable<Test> GetAll()
        {
            return storeContext.Tests.ToList();
        }
    }
}
