using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Services;

namespace MyStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            var allProducts = productService.GetProducts();

            var modelsToReturn = new List<ProductModel>();
            foreach (var product in allProducts)
            {
                modelsToReturn.Add(product.ToProductModel());
            }

            return modelsToReturn;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var productFromDb = productService.GetProduct(id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            var model = new ProductModel();
            model = productFromDb.ToProductModel();

            return Ok(model);
        }
        // PUT api/<ProductController>/5

        [HttpPut("{id}")]
        public ActionResult<ProductModel> Update(int id, ProductModel model)
        {
            var existingProduct = productService.GetProduct(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingProduct);

            var productToUpdate = new Product();
            productToUpdate = model.ToProduct();
            productService.Update(productToUpdate);

            return Ok(productToUpdate.ToProductModel());
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Create(ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productToSave = new Product();
            productToSave = model.ToProduct();


            productService.InsertNew(productToSave);

            model.Productid = productToSave.Productid;

            return CreatedAtAction(nameof(GetById), new { id = productToSave.Productid }, model);

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = productService.GetProduct(id);
            if (product == null)
            {
                return NotFound(product);
            }

            productService.Remove(product);

            return NoContent();
        }
    }
}
