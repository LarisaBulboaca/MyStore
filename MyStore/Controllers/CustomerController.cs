using Microsoft.AspNetCore.Mvc;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: api/<customerController>
        [HttpGet]
        public IEnumerable<CustomerModel> Get()
        {
            var allCustomers = customerService.GetCustomers();

            var modelsToReturn = new List<CustomerModel>();
            foreach (var customer in allCustomers)
            {
                modelsToReturn.Add(customer.ToCustomerModel());
            }

            return modelsToReturn;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            var customerFromDb = customerService.GetCustomer(id);

            if (customerFromDb == null)
            {
                return NotFound();
            }

            var model = new CustomerModel();
            model = customerFromDb.ToCustomerModel();

            return Ok(model);
        }
        // PUT api/<CustomerController>/5

        [HttpPut("{id}")]
        public ActionResult<CustomerModel> Update(int id, CustomerModel model)
        {
            var existingCustomer = customerService.GetCustomer(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingCustomer);

            var customerToUpdate = new Customer();
            customerToUpdate = model.ToCustomer();
            customerService.Update(customerToUpdate);

            return Ok(customerToUpdate.ToCustomerModel());
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Create(CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerToSave = new Customer();
            customerToSave = model.ToCustomer();


            customerService.InsertNew(customerToSave);

            model.Custid = customerToSave.Custid;

            return CreatedAtAction(nameof(GetById), new { id = customerToSave.Custid }, model);

        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound(customer);
            }

            customerService.Remove(customer);

            return NoContent();
        }
    }
}
