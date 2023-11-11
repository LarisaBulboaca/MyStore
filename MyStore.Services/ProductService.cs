using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product? GetProduct(int id)
        {
            var existingProduct = productRepository.GetProductByID(id);
            return existingProduct;
        }

        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetAll();
        }

        public Product InsertNew(Product product)
        {
            return productRepository.Add(product);
        }

        public int Remove(Product product)
        {
            return productRepository.Delete(product);
        }

        public Product Update(Product product)
        {
            return productRepository.Update(product);
        }
    }
}
