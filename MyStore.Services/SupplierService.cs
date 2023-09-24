using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public Supplier? GetSupplier(int id)
        {
            var existingSupplier = supplierRepository.GetSupplierByID(id);
            return existingSupplier;
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return supplierRepository.GetAll();
        }

        public Supplier InsertNew(Supplier supplier)
        {
            return supplierRepository.Add(supplier);
        }
        
        public int Remove(Supplier supplier)
        {
            return supplierRepository.Delete(supplier);
        }

        public Supplier Update(Supplier supplier)
        {
            return supplierRepository.Update(supplier);
        }
    }
}
