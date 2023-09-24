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
    public class SupplierController : ControllerBase
    {
        
        
        private readonly ISupplierService supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            this.supplierService =  supplierService;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public IEnumerable<SupplierModel> Get()
        {
            var allSuppliers = supplierService.GetSuppliers();
            
            var modelsToReturn = new List<SupplierModel>();
            foreach (var supplier in allSuppliers)
            {
                modelsToReturn.Add(supplier.ToSupplierModel());
            }

            return modelsToReturn;
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var supplierFromDb = supplierService.GetSupplier(id);
            if (supplierFromDb == null)
            {
                return NotFound();
            }
            
            var model = new SupplierModel();
            model = supplierFromDb.ToSupplierModel();

            return Ok(model);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public IActionResult Create(SupplierModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var supplierToSave = new Supplier();
            supplierToSave = model.ToSupplier();

            supplierService.InsertNew(supplierToSave);

            model.Supplierid = supplierToSave.Supplierid;

            return CreatedAtAction(nameof(GetById), new {id = supplierToSave.Supplierid}, model);
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public ActionResult<SupplierModel> Update(int id, SupplierModel model)
        {
            var existingSupplier = supplierService.GetSupplier(id);
            if (existingSupplier == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingSupplier);

            var supplierToUpdate = new Supplier();
            supplierToUpdate = model.ToSupplier();
            supplierService.Update(supplierToUpdate);

            return Ok();
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var supplier = supplierService.GetSupplier(id);

            if (supplier == null)
            {
                return NotFound(supplier);
            }

            supplierService.Remove(supplier);

            return NoContent();
        }


    }
}
