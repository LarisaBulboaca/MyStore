using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Services;

namespace MyStore.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<EmployeeModel> Get()
        {
            var allEmployees = employeeService.GetEmployees();

            var modelsToReturn = new List<EmployeeModel>();
            foreach (var employee in allEmployees)
            {
                modelsToReturn.Add(employee.ToEmployeeModel());
            }

            return modelsToReturn;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            var employeeFromDb = employeeService.GetEmployee(id);

            if (employeeFromDb == null)
            {
                return NotFound();
            }

            var model = new EmployeeModel();
            model = employeeFromDb.ToEmployeeModel();

            return Ok(model);
        }
        // PUT api/<EmployeeController>/5

        [HttpPut("{id}")]
        public ActionResult<EmployeeModel> Update(int id, EmployeeModel model)
        {
            var existingEmployee = employeeService.GetEmployee(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingEmployee);

            var employeeToUpdate = new Employee();
            employeeToUpdate = model.ToEmployee();
            employeeService.Update(employeeToUpdate);

            return Ok(employeeToUpdate.ToEmployeeModel());
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Create(EmployeeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeToSave = new Employee();
            employeeToSave = model.ToEmployee();


            employeeService.InsertNew(employeeToSave);

            model.Empid = employeeToSave.Empid;

            return CreatedAtAction(nameof(GetById), new { id = employeeToSave.Empid }, model);

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound(employee);
            }

            employeeService.Remove(employee);

            return NoContent();
        }
    }
}
