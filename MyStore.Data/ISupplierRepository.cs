using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface ISupplierRepository
    {
        Supplier Add(Supplier supplier);
        int Delete(Supplier supplier);
        IEnumerable<Supplier> GetAll();
        Supplier? GetSupplierByID(int id);
        Supplier Update(Supplier supplier);
    }
}
