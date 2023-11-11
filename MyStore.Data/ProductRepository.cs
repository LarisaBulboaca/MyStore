using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Product? GetProductByID(int id)
        {
            return storeContext.Products.Find(id);
        }

        public Product Add(Product product)
        {
            var addedEntity = storeContext.Products.Add(product).Entity;
            storeContext.SaveChanges();
            return addedEntity;
        }

        public int Delete(Product product)
        {
            storeContext.Products.Remove(product);
            return storeContext.SaveChanges();
        }

        public Product Update(Product product)
        {
            var updatedEntity = storeContext.Products.Update(product).Entity;
            storeContext.SaveChanges();
            return updatedEntity;
        }

        public IEnumerable<Product> GetAll()
        {
            return storeContext.Products.ToList();
        }
    }
}
