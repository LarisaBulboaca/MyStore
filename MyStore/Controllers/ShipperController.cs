using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        
        private readonly IShipperService shipperService;

        public ShipperController(IShipperService shipperService)
        {
            this.shipperService = shipperService;
        }

        // GET: api/<ShipperController>
        [HttpGet]
        public IEnumerable<ShipperModel> Get()
        {
            var allShippers = shipperService.GetShippers();
            
            var modelsToReturn = new List<ShipperModel>();
            foreach (var shipper in allShippers)
            {
                modelsToReturn.Add(shipper.ToShipperModel());
            }

            return modelsToReturn;
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public ActionResult<Shipper> GetById(int id)
        {
            var shipperFromDb = shipperService.GetShipper(id);

            if (shipperFromDb == null) 
            {
                return NotFound();
            }

            var model = new ShipperModel();
            model =  shipperFromDb.ToShipperModel();

            return Ok(model);
        }
        // PUT api/<ShipperController>/5

        [HttpPut("{id}")]
        public ActionResult<ShipperModel> Update(int id, ShipperModel model)
        {
            var existingShipper = shipperService.GetShipper(id);
            if (existingShipper == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingShipper);

            var shipperToUpdate = new Shipper();
            shipperToUpdate = model.ToShipper();
            shipperService.Update(shipperToUpdate);

            return Ok(shipperToUpdate.ToShipperModel());
        }

        // POST api/<ShipperController>
        [HttpPost]
        public IActionResult Create(ShipperModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shipperToSave = new Shipper();
            shipperToSave = model.ToShipper();
           

            shipperService.InsertNew(shipperToSave);

            model.Shipperid = shipperToSave.Shipperid;

            return CreatedAtAction(nameof(GetById), new { id = shipperToSave.Shipperid }, model);
            
        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var shipper = shipperService.GetShipper(id);
            if (shipper == null)
            {
                return NotFound(shipper);
            }
            
            shipperService.Remove(shipper);

            return NoContent();
        }
    }
}
