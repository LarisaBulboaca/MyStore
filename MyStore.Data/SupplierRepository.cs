using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly StoreContext storeContext;

        public SupplierRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Supplier? GetSupplierByID(int id)
        {
            return storeContext.Suppliers.Find(id);
        }

        public Supplier Add(Supplier supplier)
        {
            var addedEntity = storeContext.Suppliers.Add(supplier).Entity;
            storeContext.SaveChanges();
            return addedEntity;
        }

        public int Delete(Supplier supplier)
        {
            storeContext.Suppliers.Remove(supplier);
            return storeContext.SaveChanges();
        }

        public Supplier Update(Supplier supplier) 
        {
            var updatedEntity = storeContext.Suppliers.Update(supplier).Entity;
            storeContext.SaveChanges();
            return updatedEntity;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return storeContext.Suppliers.ToList();
        }
    }
}
