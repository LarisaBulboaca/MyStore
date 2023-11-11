using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Services;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumController : Controller
    {

        private readonly INumService numService;

        public NumController(INumService numService)
        {
            this.numService = numService;
        }

        // GET: api/<numController>
        [HttpGet]
        public IEnumerable<NumModel> Get()
        {
            var allNums = numService.GetNums();

            var modelsToReturn = new List<NumModel>();
            foreach (var num in allNums)
            {
                modelsToReturn.Add(num.ToNumModel());
            }

            return modelsToReturn;
        }

        // GET api/<NumController>/5
        [HttpGet("{id}")]
        public ActionResult<Num> GetById(int id)
        {
            var numFromDb = numService.GetNum(id);

            if (numFromDb == null)
            {
                return NotFound();
            }

            var model = new NumModel();
            model = numFromDb.ToNumModel();

            return Ok(model);
        }
        // PUT api/<NumController>/5

        [HttpPut("{id}")]
        public ActionResult<NumModel> Update(int id, NumModel model)
        {
            var existingNum = numService.GetNum(id);
            if (existingNum == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingNum);

            var numToUpdate = new Num();
            numToUpdate = model.ToNum();
            numService.Update(numToUpdate);

            return Ok(numToUpdate.ToNumModel());
        }

        // POST api/<NumController>
        [HttpPost]
        public IActionResult Create(NumModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var numToSave = new Num();
            numToSave = model.ToNum();


            numService.InsertNew(numToSave);

            model.N = numToSave.N;

            return CreatedAtAction(nameof(GetById), new { id = numToSave.N }, model);

        }

        // DELETE api/<NumController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var num = numService.GetNum(id);
            if (num == null)
            {
                return NotFound(num);
            }

            numService.Remove(num);

            return NoContent();
        }
    }
}
