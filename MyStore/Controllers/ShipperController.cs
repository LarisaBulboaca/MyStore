using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly StoreContext context;

        public ShipperController (StoreContext context)
        {
            this.context = context;
        }
        // GET: api/<ShipperController>
        [HttpGet]
        public IEnumerable<Shipper> Get()
        {
            var allShippers = context.Shippers.ToList();
            return allShippers;
       
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public Shipper? GetById(int id)
        {
            var shipper = context.Shippers.Find(id);
            return shipper; 
        }
        // PUT api/<ShipperController>/5

        [HttpPut("{id}")]
        public Shipper Update(int id, Shipper shipper)
        {
            var existingShipper = context.Shippers.Find(id);
            if (existingShipper != null)
            {
                TryUpdateModelAsync(existingShipper);
                context.Shippers.Update(shipper);
                context.SaveChanges();
            }
            return shipper;
        }

        // POST api/<ShipperController>
        [HttpPost]
        public Shipper Create(Shipper shipperToAdd)
        {
            context.Add(shipperToAdd);
            context.SaveChanges();

            return shipperToAdd;
        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
