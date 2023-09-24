using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Services;
using System.Globalization;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
          this.categoryService = categoryService;
        }


        [HttpGet]
        public IEnumerable<CategoryModel> Get(string? text, int pag = 1)
        {
            //implementam paginarea unor rezultate
            //adaugam un filtru de cautare in description dupa un nr de caractere
            var pageSize = 2;
            //le luam pe toate
            var allCategories = categoryService.GetCategories(pag, text);

            //var currentPageItems = allCategories.Skip(pageSize * (pag - 1)).Take(pageSize).ToList();

            var modelsToReturn = new List<CategoryModel>();
            foreach (var category in allCategories)
            {
                modelsToReturn.Add(category.ToCategoryModels());
            }

            return modelsToReturn;
        }

        [HttpGet("{id}")]
        //[HttpGet("mycoolCategory/{id:alpha}")]
        public ActionResult<CategoryModel> GetById(int id)
        {
            var category = categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            var model = new CategoryModel();
            model = category.ToCategoryModels();
            
            return Ok(model);
        }

        [HttpPut("{id}")]
        public ActionResult<CategoryModel> Update(int id, CategoryModel model)
        {
            //verificam in db daca avem ceva cu id-ul respectiv
            //updatam daca gasim
            //returnam 404 daca nu gasim

            var existingCategory = categoryService.GetCategory(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingCategory);

            var categoryToUpdate = new Category();
            categoryToUpdate = model.ToCategory();
            categoryService.Update(categoryToUpdate);
                        
            return Ok(categoryToUpdate.ToCategoryModels);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = categoryService.GetCategory(id);

            if (category == null)
            {
                return NotFound(category);
            }
              
            categoryService.Remove(category);
            //context.SaveChanges();
            //exista?
            //stergem
            //returnam NotFound
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // business rules
            if (categoryService.IsDuplicate(model.Categoryname)) 
            {
                ModelState.AddModelError("Categoryname", $"You can't have duplicate items with the value {model.Categoryname} on Categoryname");
                return Conflict(ModelState);
            }

            var categoryToSave = new Category();
            categoryToSave = model.ToCategory();

            categoryService.InsertNew(categoryToSave);
            //context.SaveChanges();

            model.Categoryid = categoryToSave.Categoryid;
            //return Ok(categoryToAdd);

            return CreatedAtAction(nameof(GetById), new { id = categoryToSave.Categoryid }, model);
        }
    }
}
