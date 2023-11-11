using MyStore.Domain;

namespace MyStore.Services
{
    public interface IProductService
    {
        Product? GetProduct(int id);
        IEnumerable<Product> GetProducts();
        Product InsertNew(Product product);
        int Remove(Product product);
        Product Update(Product product);
    }
}