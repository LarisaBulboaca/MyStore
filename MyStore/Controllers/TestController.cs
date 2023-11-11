using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Services;

namespace MyStore.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService testService;

        public TestController(ITestService testService)
        {
            this.testService = testService;
        }

        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<TestModel> Get()
        {
            var allTests = testService.GetTests();

            var modelsToReturn = new List<TestModel>();
            foreach (var test in allTests)
            {
                modelsToReturn.Add(test.ToTestModel());
            }

            return modelsToReturn;
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public ActionResult<Test> GetById(int id)
        {
            var testFromDB = testService.GetTest(id);

            if (testFromDB == null)
            {
                return NotFound();
            }

            var model = new TestModel();
            model = testFromDB.ToTestModel();

            return Ok(model);
        }
        // PUT api/<TestController>/5

        [HttpPut("{id}")]
        public ActionResult<TestModel> Update(int id, TestModel model)
        {
            var existingTest = testService.GetTest(id);
            if (existingTest == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingTest);

            var testToUpdate = new Test();
            testToUpdate = model.ToTest();
            testService.Update(testToUpdate);

            return Ok(testToUpdate.ToTestModel());
        }

        // POST api/<TestController>
        [HttpPost]
        public IActionResult Create(TestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testToSave = new Test();
            testToSave = model.ToTest();


            testService.InsertNew(testToSave);

            model.Testid = testToSave.Testid;

            return CreatedAtAction(nameof(GetById), new { id = testToSave.Testid }, model);

        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var test = testService.GetTest(id);
            if (test == null)
            {
                return NotFound(test);
            }

            testService.Remove(test);

            return NoContent();
        }
    }
}
