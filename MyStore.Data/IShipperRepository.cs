using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface IShipperRepository
    {
        Shipper Add(Shipper shipper);
        int Delete(Shipper shipper);
        IEnumerable<Shipper> GetAll();
        Shipper? GetShipperByID(int id);
        Shipper Update(Shipper shipper);
    }
}
