using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IShipperService
    {
        Shipper? GetShipper(int id);
        IEnumerable<Shipper> GetShippers();
        Shipper InsertNew(Shipper shipper);
        int Remove(Shipper shipper);
        Shipper Update(Shipper shipper);
    }
}
