using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class NumRepository : INumRepository
    {
        private readonly StoreContext storeContext;

        public NumRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Num? GetNumByID(int id)
        {
            return storeContext.Nums.Find(id);
        }

        public Num Add(Num num)
        {
            var addedEntity = storeContext.Nums.Add(num).Entity;
            storeContext.SaveChanges();
            return addedEntity;
        }

        public int Delete(Num num)
        {
            storeContext.Nums.Remove(num);
            return storeContext.SaveChanges();
        }

        public Num Update(Num num)
        {
            var updatedEntity = storeContext.Nums.Update(num).Entity;
            storeContext.SaveChanges();
            return updatedEntity;
        }

        public IEnumerable<Num> GetAll()
        {
            return storeContext.Nums.ToList();
        }
    }
}
