using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface ISupplierService
    {
        Supplier? GetSupplier(int id);
        IEnumerable<Supplier> GetSuppliers();
        Supplier InsertNew(Supplier supplier);
        int Remove(Supplier supplier);
        Supplier Update(Supplier supplier);
    }
}
