using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository shipperRepository;

        public ShipperService(IShipperRepository shipperRepository)
        {
            this.shipperRepository = shipperRepository;
        }

        public Shipper? GetShipper(int id)
        {
            var existingShipper = shipperRepository.GetShipperByID(id);
            return existingShipper;
        }

        public IEnumerable<Shipper> GetShippers() 
        {
            return shipperRepository.GetAll();
        }

        public Shipper InsertNew(Shipper shipper)
        {
            return shipperRepository.Add(shipper);
        }

        public int Remove(Shipper shipper)
        {
            return shipperRepository.Delete(shipper);
        }

        public Shipper Update(Shipper shipper)
        {
            return shipperRepository.Update(shipper);
        }
    }
}
