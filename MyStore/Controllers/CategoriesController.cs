using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly StoreContext context;

        public CategoriesController(StoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Category> Get() 
        { 
            var allCategories = context.Categories.ToList();
            return allCategories;
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetById(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPut("{id}")]
        public ActionResult<Category> Update(int id, Category category)
        {
            //verificam in db daca avem ceva cu id-ul respectiv
            //updatam daca gasim
            //returnam 404 daca nu gasim

            var existingCategory = context.Categories.Find(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingCategory);
            context.Categories.Update(category);
            context.SaveChanges();
            
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound(category);
            }
              
            context.Categories.Remove(category);
            context.SaveChanges();
            //exista?
            //stergem
            //returnam NotFound
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(Category categoryToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // TODO: business rules

            var addedEntity = context.Add(categoryToAdd);
            context.SaveChanges();

            //return Ok(categoryToAdd);

            return CreatedAtAction(nameof(GetById), new { id = categoryToAdd.Categoryid }, categoryToAdd);
        }
    }
}
